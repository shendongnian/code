    using System;
    using System.Runtime.InteropServices;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            const int SystemPowerInformation = 12;
            const uint STATUS_SUCCESS = 0;
    
            struct SYSTEM_POWER_INFORMATION
            {
                public uint MaxIdlenessAllowed;
                public uint Idleness;
                public uint TimeRemaining;
                public byte CoolingMode;
            }
    
            [DllImport("powrprof.dll")]
            static extern uint CallNtPowerInformation(
                int InformationLevel,
                IntPtr lpInputBuffer,
                int nInputBufferSize,
                out SYSTEM_POWER_INFORMATION spi,
                int nOutputBufferSize
            );
    
            static void Main(string[] args)
            {
                SYSTEM_POWER_INFORMATION spi;
                uint retval = CallNtPowerInformation(
                    SystemPowerInformation,
                    IntPtr.Zero,
                    0,
                    out spi,
                    Marshal.SizeOf(typeof(SYSTEM_POWER_INFORMATION))
                );
                if (retval == STATUS_SUCCESS)
                    Console.WriteLine(spi.TimeRemaining);
                Console.ReadLine();
            }
        }
    }
