    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const int ProcessorInformation = 11;
            const uint STATUS_SUCCESS = 0;
    
            [StructLayout(LayoutKind.Sequential)]
            struct PROCESSOR_POWER_INFORMATION
            {
                public uint Number;
                public uint MaxMhz;
                public uint CurrentMhz;
                public uint MhzLimit;
                public uint MaxIdleState;
                public uint CurrentIdleState;
            }
    
            [DllImport("powrprof.dll")]
            static extern uint CallNtPowerInformation(
                int InformationLevel,
                IntPtr lpInputBuffer,
                int nInputBufferSize,
                [Out] PROCESSOR_POWER_INFORMATION[] lpOutputBuffer,
                int nOutputBufferSize
            );
    
            static void Main(string[] args)
            {
                int procCount = Environment.ProcessorCount;
                PROCESSOR_POWER_INFORMATION[] procInfo =
                    new PROCESSOR_POWER_INFORMATION[procCount]; 
                uint retval = CallNtPowerInformation(
                    ProcessorInformation,
                    IntPtr.Zero,
                    0,
                    procInfo,
                    procInfo.Length * Marshal.SizeOf(typeof(PROCESSOR_POWER_INFORMATION))
                );
                if (retval == STATUS_SUCCESS)
                {
                    foreach (var item in procInfo)
                    {
                        Console.WriteLine(item.CurrentMhz);
                    }
                }
            }
        }
    }
