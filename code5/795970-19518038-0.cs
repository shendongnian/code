    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using EmpireCLS.Comm;
    
    namespace StructTestLib
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4, CharSet = CharSet.Ansi)]
        public struct STRUCT_Test
        {
            public Int32 IntValue1;
            public Int32 IntValue2;
    
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
            public string StringValue1;
        
        }
        
        public class StructReader
        {
            unsafe public void ReadDataRaw(int uniqueId, void* tripRecordPtr)
            {
                STRUCT_Test tripRecord = (STRUCT_Test)Marshal.PtrToStructure((IntPtr)tripRecordPtr, typeof(STRUCT_Test));
               
                tripRecord.IntValue1 = 3333;
                tripRecord.IntValue2 = 4444;
    
                Console.WriteLine("c# StringValue1: " + tripRecord.StringValue1);
                tripRecord.StringValue1 = "fghij";
    
                GCHandle pinnedPacket = new GCHandle();
                try
                {
                    int structSizeInBytes = Marshal.SizeOf(typeof(STRUCT_Test));
    
                    byte[] bytes = new byte[structSizeInBytes];
                    pinnedPacket = GCHandle.Alloc(bytes, GCHandleType.Pinned);
    
                    Marshal.StructureToPtr(tripRecord, pinnedPacket.AddrOfPinnedObject(), true);
                    Marshal.Copy(bytes, 0, (IntPtr)tripRecordPtr, bytes.Length);
    
                }
                finally
                {
                    if (pinnedPacket.IsAllocated)
                        pinnedPacket.Free();
                }
            }
        }
    }
