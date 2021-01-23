    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    namespace ServerEnumDemo
    {
        public sealed class TsClientSharesProvider : IDisposable
        {
            private IntPtr handle = IntPtr.Zero;
            private IntPtr buffer = IntPtr.Zero;
            private IList<string> result;
            public IEnumerable<string> GetUncPaths()
            {
                if (result != null)
                {
                    return result;
                }
                result = new List<string>();
                EnumerateTsclientShares(result, new Win32.NETRESOURCE());
                return result;
            }
            public void Dispose()
            {
                if (handle != IntPtr.Zero)
                {
                    Win32.WNetCloseEnum(handle);
                    handle = IntPtr.Zero;
                }
                if (buffer != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buffer);
                    buffer = IntPtr.Zero;
                }
            }
            private void EnumerateTsclientShares(ICollection<string> result, Win32.NETRESOURCE pRsrc)
            {
                uint bufferSize = 16384;
                buffer = Marshal.AllocHGlobal((int)bufferSize);
                uint cEntries = 1;
                var returncode = Win32.WNetOpenEnum(Win32.ResourceScope.RESOURCE_GLOBALNET, Win32.ResourceType.RESOURCETYPE_DISK,
                    Win32.ResourceUsage.RESOURCEUSAGE_ALL, pRsrc, out handle);
                if (returncode != Win32.ErrorCodes.NO_ERROR)
                {
                    throw new Exception("Could not enumerate network shares");
                }
                do
                {
                    returncode = Win32.WNetEnumResource(handle, ref cEntries, buffer, ref bufferSize);
                    if (returncode == Win32.ErrorCodes.NO_ERROR)
                    {
                        Marshal.PtrToStructure(buffer, pRsrc);
                        if ((pRsrc.dwUsage == Win32.ResourceUsage.RESOURCEUSAGE_CONNECTABLE)
                            && pRsrc.lpLocalName.Contains("tsclient"))
                        {
                            result.Add(pRsrc.lpLocalName);
                        }
                        if ((pRsrc.dwUsage & Win32.ResourceUsage.RESOURCEUSAGE_CONTAINER) ==
                            Win32.ResourceUsage.RESOURCEUSAGE_CONTAINER)
                        {
                            EnumerateTsclientShares(result, pRsrc);
                        }
                    }
                    else if (returncode != Win32.ErrorCodes.ERROR_NO_MORE_ITEMS)
                    {
                        Console.WriteLine("ERROR " + returncode);
                    }
                } while (returncode != Win32.ErrorCodes.ERROR_NO_MORE_ITEMS);
            }
        }
    }
