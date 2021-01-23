        internal static readonly IntPtr HKEY_CLASSES_ROOT = new IntPtr(unchecked((int)0x80000000));
        internal static readonly IntPtr HKEY_CURRENT_USER = new IntPtr(unchecked((int)0x80000001));
        internal static readonly IntPtr HKEY_LOCAL_MACHINE = new IntPtr(unchecked((int)0x80000002));
        internal static readonly IntPtr HKEY_USERS = new IntPtr(unchecked((int)0x80000003));
        internal static readonly IntPtr HKEY_PERFORMANCE_DATA = new IntPtr(unchecked((int)0x80000004));
        internal static readonly IntPtr HKEY_CURRENT_CONFIG = new IntPtr(unchecked((int)0x80000005));
        private static readonly String[] hkeyNames = new String[] {
                "HKEY_CLASSES_ROOT",
                "HKEY_CURRENT_USER",
                "HKEY_LOCAL_MACHINE",
                "HKEY_USERS",
                "HKEY_PERFORMANCE_DATA",
                "HKEY_CURRENT_CONFIG",
                };
        public Object GetValue(String name)
        {
            return InternalGetValue(name, null, false, true);
        }
        internal Object InternalGetValue(String name, Object defaultValue, bool doNotExpand, bool checkSecurity)
        {
            Object data = defaultValue;
            int type = 0;
            int datasize = 0;
            int ret = Win32Native.RegQueryValueEx(hkey, name, null, ref type, (byte[])null, ref datasize);
            if (ret != 0)
            {
                if (IsPerfDataKey())
                {
                    int size = 65000;
                    int sizeInput = size;
                    int r;
                    byte[] blob = new byte[size];
                    while (Win32Native.ERROR_MORE_DATA == (r = Win32Native.RegQueryValueEx(hkey, name, null, ref type, blob, ref sizeInput)))
                    {
                        if (size == Int32.MaxValue)
                        {
                            // ERROR_MORE_DATA was returned however we cannot increase the buffer size beyond Int32.MaxValue
                            //Win32Error(r, name);
                            Console.WriteLine(string.Format("[{0}] [{1}]", r,name));
                        }
                        else if (size > (Int32.MaxValue / 2))
                        {
                            // at this point in the loop "size * 2" would cause an overflow
                            size = Int32.MaxValue;
                        }
                        else
                        {
                            size *= 2;
                        }
                        sizeInput = size;
                        blob = new byte[size];
                    }
                    if (r != 0)
                        Console.WriteLine(string.Format("[{0}] [{1}]", r, name));
                    return blob;
                }
                else
                {
                    // For stuff like ERROR_FILE_NOT_FOUND, we want to return null (data).
                    // Some OS's returned ERROR_MORE_DATA even in success cases, so we 
                    // want to continue on through the function. 
                    if (ret != Win32Native.ERROR_MORE_DATA)
                        return data;
                }
            }
            if (datasize < 0)
            {
                // unexpected code path
                //BCLDebug.Assert(false, "[InternalGetValue] RegQueryValue returned ERROR_SUCCESS but gave a negative datasize");
                datasize = 0;
            }
            switch (type)
            {
                case Win32Native.REG_NONE:
                case Win32Native.REG_DWORD_BIG_ENDIAN:
                case Win32Native.REG_BINARY:
                    {
                        byte[] blob = new byte[datasize];
                        ret = Win32Native.RegQueryValueEx(hkey, name, null, ref type, blob, ref datasize);
                        data = blob;
                    }
                    break;
                case Win32Native.REG_QWORD:
                    {    // also REG_QWORD_LITTLE_ENDIAN
                        if (datasize > 8)
                        {
                            // prevent an AV in the edge case that datasize is larger than sizeof(long)
                            goto case Win32Native.REG_BINARY;
                        }
                        long blob = 0;
                        //BCLDebug.Assert(datasize==8, "datasize==8");
                        // Here, datasize must be 8 when calling this
                        ret = Win32Native.RegQueryValueEx(hkey, name, null, ref type, ref blob, ref datasize);
                        data = blob;
                    }
                    break;
                case Win32Native.REG_DWORD:
                    {    // also REG_DWORD_LITTLE_ENDIAN
                        if (datasize > 4)
                        {
                            // prevent an AV in the edge case that datasize is larger than sizeof(int)
                            goto case Win32Native.REG_QWORD;
                        }
                        int blob = 0;
                        // Here, datasize must be four when calling this
                        ret = Win32Native.RegQueryValueEx(hkey, name, null, ref type, ref blob, ref datasize);
                        data = blob;
                    }
                    break;
                case Win32Native.REG_SZ:
                    {
                        if (datasize % 2 == 1)
                        {
                            // handle the case where the registry contains an odd-byte length (corrupt data?)
                            try
                            {
                                datasize = checked(datasize + 1);
                            }
                            catch (OverflowException e)
                            {
                                throw new IOException(("Arg_RegGetOverflowBug"), e);
                            }
                        }
                        char[] blob = new char[datasize / 2];
                        ret = Win32Native.RegQueryValueEx(hkey, name, null, ref type, blob, ref datasize);
                        if (blob.Length > 0 && blob[blob.Length - 1] == (char)0)
                        {
                            data = new String(blob, 0, blob.Length - 1);
                        }
                        else
                        {
                            // in the very unlikely case the data is missing null termination, 
                            // pass in the whole char[] to prevent truncating a character
                            data = new String(blob);
                        }
                    }
                    break;
                case Win32Native.REG_EXPAND_SZ:
                    {
                        if (datasize % 2 == 1)
                        {
                            // handle the case where the registry contains an odd-byte length (corrupt data?)
                            try
                            {
                                datasize = checked(datasize + 1);
                            }
                            catch (OverflowException e)
                            {
                                throw new IOException(("Arg_RegGetOverflowBug"), e);
                            }
                        }
                        char[] blob = new char[datasize / 2];
                        ret = Win32Native.RegQueryValueEx(hkey, name, null, ref type, blob, ref datasize);
                        if (blob.Length > 0 && blob[blob.Length - 1] == (char)0)
                        {
                            data = new String(blob, 0, blob.Length - 1);
                        }
                        else
                        {
                            // in the very unlikely case the data is missing null termination, 
                            // pass in the whole char[] to prevent truncating a character
                            data = new String(blob);
                        }
                        if (!doNotExpand)
                            data = Environment.ExpandEnvironmentVariables((String)data);
                    }
                    break;
                case Win32Native.REG_MULTI_SZ:
                    {
                        if (datasize % 2 == 1)
                        {
                            // handle the case where the registry contains an odd-byte length (corrupt data?)
                            try
                            {
                                datasize = checked(datasize + 1);
                            }
                            catch (OverflowException e)
                            {
                                throw new IOException(("Arg_RegGetOverflowBug"), e);
                            }
                        }
                        char[] blob = new char[datasize / 2];
                        ret = Win32Native.RegQueryValueEx(hkey, name, null, ref type, blob, ref datasize);
                        // make sure the string is null terminated before processing the data
                        if (blob.Length > 0 && blob[blob.Length - 1] != (char)0)
                        {
                            try
                            {
                                char[] newBlob = new char[checked(blob.Length + 1)];
                                for (int i = 0; i < blob.Length; i++)
                                {
                                    newBlob[i] = blob[i];
                                }
                                newBlob[newBlob.Length - 1] = (char)0;
                                blob = newBlob;
                            }
                            catch (OverflowException e)
                            {
                                throw new IOException(("Arg_RegGetOverflowBug"), e);
                            }
                            blob[blob.Length - 1] = (char)0;
                        }
                        IList<String> strings = new List<String>();
                        int cur = 0;
                        int len = blob.Length;
                        while (ret == 0 && cur < len)
                        {
                            int nextNull = cur;
                            while (nextNull < len && blob[nextNull] != (char)0)
                            {
                                nextNull++;
                            }
                            if (nextNull < len)
                            {
                                //BCLDebug.Assert(blob[nextNull] == (char)0, "blob[nextNull] should be 0");
                                if (nextNull - cur > 0)
                                {
                                    strings.Add(new String(blob, cur, nextNull - cur));
                                }
                                else
                                {
                                    // we found an empty string.  But if we're at the end of the data, 
                                    // it's just the extra null terminator. 
                                    if (nextNull != len - 1)
                                        strings.Add(String.Empty);
                                }
                            }
                            else
                            {
                                strings.Add(new String(blob, cur, len - cur));
                            }
                            cur = nextNull + 1;
                        }
                        data = new String[strings.Count];
                        strings.CopyTo((String[])data, 0);
                    }
                    break;
                case Win32Native.REG_LINK:
                default:
                    break;
            }
            return data;
        }
        public String[] GetSubKeyNames()
        {
            return InternalGetSubKeyNames();
        }
        public RegistryKey OpenSubKey(string name, bool writable=false)
        {
            name = FixupName(name); // Fixup multiple slashes to a single slash            
            SafeRegistryHandle result = null;
            int ret = Win32Native.RegOpenKeyEx(hkey,
                name,
                0,
                GetRegistryKeyAccess(writable) | (int)regView,
                out result);
            if (ret == 0 && !result.IsInvalid)
            {
                RegistryKey key = new RegistryKey(result, writable, false, remoteKey, false, regView);
                key.checkMode = GetSubKeyPermissonCheck(writable);
                key.keyName = keyName + "\\" + name;
                return key;
            }
            // Return null if we didn't find the key.
            if (ret == Win32Native.ERROR_ACCESS_DENIED || ret == Win32Native.ERROR_BAD_IMPERSONATION_LEVEL)
            {
                // We need to throw SecurityException here for compatibility reasons,
                // although UnauthorizedAccessException will make more sense.
                //ThrowHelper.ThrowSecurityException(ExceptionResource.Security_RegistryPermission);
            }
            return null;
        }
        private const int MaxKeyLength = 255;
        internal unsafe String[] InternalGetSubKeyNames()
        {
            int subkeys = InternalSubKeyCount();
            String[] names = new String[subkeys];  // Returns 0-length array if empty.
            if (subkeys > 0)
            {
                char[] name = new char[MaxKeyLength + 1];
                int namelen;
                fixed (char* namePtr = &name[0])
                {
                    for (int i = 0; i < subkeys; i++)
                    {
                        namelen = name.Length; // Don't remove this. The API's doesn't work if this is not properly initialised.
                        int ret = Win32Native.RegEnumKeyEx(hkey,
                            i,
                            namePtr,
                            ref namelen,
                            null,
                            null,
                            null,
                            null);
                        if (ret != 0)
                            //Win32Error(ret, null);
                            Console.WriteLine(ret);
                        names[i] = new String(namePtr);
                    }
                }
            }
            return names;
        }
        internal int InternalSubKeyCount()
        {
            int subkeys = 0;
            int junk = 0;
            int ret = Win32Native.RegQueryInfoKey(hkey,
                                      null,
                                      null,
                                      IntPtr.Zero,
                                      ref subkeys,  // subkeys
                                      null,
                                      null,
                                      ref junk,     // values
                                      null,
                                      null,
                                      null,
                                      null);
            if (ret != 0)
                //Win32Error(ret, null);
                Console.WriteLine(ret);
            return subkeys;
        }
        public static RegistryKey OpenBaseKey(RegistryHive hKey, RegistryView view)
        {
            return GetBaseKey((IntPtr)((int)hKey), view);
        }
        internal static RegistryKey GetBaseKey(IntPtr hKey, RegistryView view)
        {
            int index = ((int)hKey) & 0x0FFFFFFF;
            //BCLDebug.Assert(index >= 0  && index < hkeyNames.Length, "index is out of range!");
            //BCLDebug.Assert((((int)hKey) & 0xFFFFFFF0) == 0x80000000, "Invalid hkey value!");
            bool isPerf = hKey == HKEY_PERFORMANCE_DATA;
            // only mark the SafeHandle as ownsHandle if the key is HKEY_PERFORMANCE_DATA.
            SafeRegistryHandle srh = new SafeRegistryHandle(hKey, isPerf);
            RegistryKey key = new RegistryKey(srh, true, true, false, isPerf, view);
            key.checkMode = RegistryKeyPermissionCheck.Default;
            key.keyName = hkeyNames[index];
            return key;
        }
        private volatile SafeRegistryHandle hkey = null;
        private volatile int state = 0;
        private volatile String keyName;
        private volatile bool remoteKey = false;
        private volatile RegistryKeyPermissionCheck checkMode;
        private volatile RegistryView regView = RegistryView.Default;
        private const int STATE_DIRTY = 0x0001;
        // SystemKey indicates that this is a "SYSTEMKEY" and shouldn't be "opened"
        // or "closed".
        //
        private const int STATE_SYSTEMKEY = 0x0002;
        // Access
        //
        private const int STATE_WRITEACCESS = 0x0004;
        // Indicates if this key is for HKEY_PERFORMANCE_DATA
        private const int STATE_PERF_DATA = 0x0008;
        private RegistryKey(SafeRegistryHandle hkey, bool writable, bool systemkey, bool remoteKey, bool isPerfData, RegistryView view)
        {
            this.hkey = hkey;
            this.keyName = "";
            this.remoteKey = remoteKey;
            this.regView = view;
            if (systemkey)
            {
                this.state |= STATE_SYSTEMKEY;
            }
            if (writable)
            {
                this.state |= STATE_WRITEACCESS;
            }
            if (isPerfData)
                this.state |= STATE_PERF_DATA;
        }
        private RegistryKeyPermissionCheck GetSubKeyPermissonCheck(bool subkeyWritable)
        {
            if (checkMode == RegistryKeyPermissionCheck.Default)
            {
                return checkMode;
            }
            if (subkeyWritable)
            {
                return RegistryKeyPermissionCheck.ReadWriteSubTree;
            }
            else
            {
                return RegistryKeyPermissionCheck.ReadSubTree;
            }
        }
        static int GetRegistryKeyAccess(bool isWritable)
        {
            int winAccess;
            if (!isWritable)
            {
                winAccess = Win32Native.KEY_READ;
            }
            else
            {
                winAccess = Win32Native.KEY_READ | Win32Native.KEY_WRITE;
            }
            return winAccess;
        }
        internal static String FixupName(String name)
        {
            //BCLDebug.Assert(name!=null,"[FixupName]name!=null");
            if (name.IndexOf('\\') == -1)
                return name;
            StringBuilder sb = new StringBuilder(name);
            FixupPath(sb);
            int temp = sb.Length - 1;
            if (temp >= 0 && sb[temp] == '\\') // Remove trailing slash
                sb.Length = temp;
            return sb.ToString();
        }
        private static void FixupPath(StringBuilder path)
        {
            //Contract.Requires(path != null);
            int length = path.Length;
            bool fixup = false;
            char markerChar = (char)0xFFFF;
            int i = 1;
            while (i < length - 1)
            {
                if (path[i] == '\\')
                {
                    i++;
                    while (i < length)
                    {
                        if (path[i] == '\\')
                        {
                            path[i] = markerChar;
                            i++;
                            fixup = true;
                        }
                        else
                            break;
                    }
                }
                i++;
            }
            if (fixup)
            {
                i = 0;
                int j = 0;
                while (i < length)
                {
                    if (path[i] == markerChar)
                    {
                        i++;
                        continue;
                    }
                    path[j] = path[i];
                    i++;
                    j++;
                }
                path.Length += j - i;
            }
        }
        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用
        public void Close()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (hkey != null)
            {
                if (!IsSystemKey())
                {
                    try
                    {
                        hkey.Dispose();
                    }
                    catch (IOException)
                    {
                        // we don't really care if the handle is invalid at this point
                    }
                    finally
                    {
                        hkey = null;
                    }
                }
                else if (disposing && IsPerfDataKey())
                {
                    // System keys should never be closed.  However, we want to call RegCloseKey
                    // on HKEY_PERFORMANCE_DATA when called from PerformanceCounter.CloseSharedResources
                    // (i.e. when disposing is true) so that we release the PERFLIB cache and cause it
                    // to be refreshed (by re-reading the registry) when accessed subsequently. 
                    // This is the only way we can see the just installed perf counter.  
                    // NOTE: since HKEY_PERFORMANCE_DATA is process wide, there is inherent race condition in closing
                    // the key asynchronously. While Vista is smart enough to rebuild the PERFLIB resources
                    // in this situation the down level OSes are not. We have a small window between  
                    // the dispose below and usage elsewhere (other threads). This is By Design. 
                    // This is less of an issue when OS > NT5 (i.e Vista & higher), we can close the perfkey  
                    // (to release & refresh PERFLIB resources) and the OS will rebuild PERFLIB as necessary. 
                    SafeRegistryHandle.RegCloseKey(RegistryKey.HKEY_PERFORMANCE_DATA);
                }
            }
        }
        private bool IsPerfDataKey()
        {
            return (this.state & STATE_PERF_DATA) != 0;
        }
        private bool IsSystemKey()
        {
            return (this.state & STATE_SYSTEMKEY) != 0;
        }
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
    [System.Security.SecurityCritical]
    public sealed class SafeRegistryHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        [System.Security.SecurityCritical]
        internal SafeRegistryHandle() : base(true) { }
        [System.Security.SecurityCritical]
        public SafeRegistryHandle(IntPtr preexistingHandle, bool ownsHandle) : base(ownsHandle)
        {
            SetHandle(preexistingHandle);
        }
        [System.Security.SecurityCritical]
        override protected bool ReleaseHandle()
        {
            return (RegCloseKey(handle) == Win32Native.ERROR_SUCCESS);
        }
        [DllImport(Win32Native.ADVAPI32)]
        internal static extern int RegCloseKey(IntPtr hKey);
    }
    [Serializable]
    [System.Runtime.InteropServices.ComVisible(true)]
    public enum RegistryHive
    {
        ClassesRoot = unchecked((int)0x80000000),
        CurrentUser = unchecked((int)0x80000001),
        LocalMachine = unchecked((int)0x80000002),
        Users = unchecked((int)0x80000003),
        PerformanceData = unchecked((int)0x80000004),
        CurrentConfig = unchecked((int)0x80000005),
    }
    public enum RegistryView
    {
        Default = 0,                           // 0x0000 operate on the default registry view
        Registry64 = Win32Native.KEY_WOW64_64KEY, // 0x0100 operate on the 64-bit registry view
        Registry32 = Win32Native.KEY_WOW64_32KEY, // 0x0200 operate on the 32-bit registry view
    };
    public enum RegistryKeyPermissionCheck
    {
        Default = 0,
        ReadSubTree = 1,
        ReadWriteSubTree = 2
    }
    public static class Win32Native
    {
        internal const String ADVAPI32 = "advapi32.dll";
        internal const int KEY_WOW64_64KEY = 0x0100;     //
        internal const int KEY_WOW64_32KEY = 0x0200;     //
        internal const int ERROR_SUCCESS = 0x0;
        internal const int READ_CONTROL = 0x00020000;
        internal const int SYNCHRONIZE = 0x00100000;
        internal const int STANDARD_RIGHTS_READ = READ_CONTROL;
        internal const int STANDARD_RIGHTS_WRITE = READ_CONTROL;
        internal const int KEY_QUERY_VALUE = 0x0001;
        internal const int KEY_SET_VALUE = 0x0002;
        internal const int KEY_CREATE_SUB_KEY = 0x0004;
        internal const int KEY_ENUMERATE_SUB_KEYS = 0x0008;
        internal const int KEY_NOTIFY = 0x0010;
        internal const int KEY_CREATE_LINK = 0x0020;
        internal const int KEY_READ = ((STANDARD_RIGHTS_READ |
                                                           KEY_QUERY_VALUE |
                                                           KEY_ENUMERATE_SUB_KEYS |
                                                           KEY_NOTIFY)
                                                          &
                                                          (~SYNCHRONIZE));
        internal const int KEY_WRITE = ((STANDARD_RIGHTS_WRITE |
                                                           KEY_SET_VALUE |
                                                           KEY_CREATE_SUB_KEY)
                                                          &
                                                          (~SYNCHRONIZE));
        internal const int ERROR_ACCESS_DENIED = 0x5;
        internal const int ERROR_BAD_IMPERSONATION_LEVEL = 0x542;
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal static extern int RegOpenKeyEx(SafeRegistryHandle hKey, String lpSubKey,
            int ulOptions, int samDesired, out SafeRegistryHandle hkResult);
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal static extern int RegQueryInfoKey(SafeRegistryHandle hKey, [Out]StringBuilder lpClass,
            int[] lpcbClass, IntPtr lpReserved_MustBeZero, ref int lpcSubKeys,
            int[] lpcbMaxSubKeyLen, int[] lpcbMaxClassLen,
            ref int lpcValues, int[] lpcbMaxValueNameLen,
            int[] lpcbMaxValueLen, int[] lpcbSecurityDescriptor,
            int[] lpftLastWriteTime);
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal unsafe static extern int RegEnumKeyEx(SafeRegistryHandle hKey, int dwIndex,
            char* lpName, ref int lpcbName, int[] lpReserved,
            [Out]StringBuilder lpClass, int[] lpcbClass,
            long[] lpftLastWriteTime);
        internal const int ERROR_MORE_DATA = 0xEA;
        internal const int REG_NONE = 0;     // No value type
        internal const int REG_DWORD_BIG_ENDIAN = 5;     // 32-bit number
        internal const int REG_BINARY = 3;     // Free form binary
        internal const int REG_QWORD = 11;    // 64-bit number
        internal const int REG_DWORD = 4;     // 32-bit number
        internal const int REG_SZ = 1;     // Unicode nul terminated string
        internal const int REG_EXPAND_SZ = 2;     // Unicode nul terminated string
        internal const int REG_MULTI_SZ = 7;     // Multiple Unicode strings
        internal const int REG_LINK = 6;     // Symbolic Link (unicode)
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                            int[] lpReserved, ref int lpType, [Out] byte[] lpData,
                            ref int lpcbData);
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, ref int lpData,
                    ref int lpcbData);
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, ref long lpData,
                    ref int lpcbData);
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                     int[] lpReserved, ref int lpType, [Out] char[] lpData,
                     ref int lpcbData);
        [DllImport(ADVAPI32, CharSet = CharSet.Auto, BestFitMapping = false)]
        internal static extern int RegQueryValueEx(SafeRegistryHandle hKey, String lpValueName,
                    int[] lpReserved, ref int lpType, [Out]StringBuilder lpData,
                    ref int lpcbData);
    }
