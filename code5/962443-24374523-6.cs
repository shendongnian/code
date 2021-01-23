    class Program
    {
        [Cudafy]
        public struct TestStruct
        {
            public double value;
            public long dataPointer; // your data pointer adress
        }
        [Cudafy]
        public static void kernelTest(GThread thread, TestStruct[] structure, int[] intArray)
        {
            // Do something 
            GThread.InsertCode("int* pointer = (int*)structure[0].dataPointer;");
            GThread.InsertCode("structure[0].value = pointer[1];");             // Here you can acces your data using pointer pointer[0], pointer[1] and so on
        }
       
        private unsafe static void Main(string[] args)
        {
                GPGPU gpuCuda = CudafyHost.GetDevice(eGPUType.Cuda, 0);
                CudafyModule km = CudafyTranslator.Cudafy();
                gpuCuda.LoadModule(km);
                TestStruct[] host_array = new TestStruct[1];
                host_array[0] = new TestStruct();
                int[] host_intArray = new[] {1, 8, 3};
                int[] dev_intArray = gpuCuda.CopyToDevice(host_intArray);
                DevicePtrEx p = gpuCuda.GetDeviceMemory(dev_intArray);
                IntPtr pointer = p.Pointer;
                host_array[0].dataPointer = pointer.ToInt64();
                TestStruct[] dev_array = gpuCuda.Allocate(host_array);
                gpuCuda.CopyToDevice(host_array, dev_array);
                gpuCuda.Launch().kernelTest(dev_array, dev_intArray);
            
                gpuCuda.CopyFromDevice(dev_array, host_array);
                Console.WriteLine(host_array[0].value);
                Console.ReadKey();
        }
    }
