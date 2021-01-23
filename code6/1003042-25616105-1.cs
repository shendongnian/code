    public GpioConnectionDriver() {
            
            using (var memoryFile = UnixFile.Open("/dev/mem", UnixFileMode.ReadWrite | UnixFileMode.Synchronized)) {
                gpioAddress = MemoryMap.Create(
                    IntPtr.Zero, 
                    Interop.BCM2835_BLOCK_SIZE,
                    MemoryProtection.ReadWrite,
                    MemoryFlags.Shared, 
                    memoryFile.Descriptor,
                    Interop.BCM2835_GPIO_BASE
                );
            }
        }
