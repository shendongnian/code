    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    
    using Cudafy;
    using Cudafy.Host;
    using Cudafy.Translator;
    
    namespace FxKernelTest 
    { 
        public class FxKernTest  
        {
            public GPGPU fxgpu;
    
            public const int N = 1024 * 64;
    
            public void ExeTestKernel()
            {
                GPGPU gpu = CudafyHost.GetDevice(CudafyModes.Target, 0);
                eArchitecture arch = gpu.GetArchitecture();
                CudafyModule km = CudafyTranslator.Cudafy(arch);
    
                gpu.LoadModule(km);
    
                int[] host_results = new int[N];
    
                // Either assign a new block of memory to hold results on device
                var dev_results = gpu.Allocate<int>(N);
    
                // Or fill your array with values first and then
                for (int i = 0; i < N; i++) host_results[i] = i * 3;
    
                // Copy array with ints to device
                var dev_filled_results = gpu.CopyToDevice(host_results);
    
                // 64*16 = 1024 threads per block (which is max for sm_30)
                dim3 threadsPerBlock = new dim3(64, 16);    
    
                // 8*8 = 64 blocks per grid , just for show so you get varying numbers 
                dim3 blocksPerGrid = new dim3(8, 8); 
                
                //var threadsPerBlock = 1024; // this will only give you blockDim.x = 1024, .y = 0, .z = 0
                //var blocksPerGrid = 1;      // just for show
    
                gpu.Launch(blocksPerGrid, threadsPerBlock, "GenerateRipples", dev_results);
    
                gpu.CopyFromDevice(dev_results, host_results); 
            }
    
            [Cudafy]
            public static void GenerateRipples(GThread thread, int[] results)
            {
                var threadId = thread.blockIdx.y * thread.gridDim.x +       // offset to grid
                               thread.blockIdx.x  +                         // index to grid
                               thread.threadIdx.y * thread.blockDim.x +     // offset to block in grid
                               thread.threadIdx.x;                          // index to block
    
                var shared = thread.AllocateShared<int>("sharedarray", 1024);
                // so i can breakpoint here
                shared[0] = 0;
    
                var threadPosInBlockX = 0;
                threadPosInBlockX = thread.threadIdx.x;
    
                var threadPosInBlockY = 0;
                threadPosInBlockY = thread.threadIdx.y;
    
                var blockPosInGridX = 0;
                blockPosInGridX = thread.blockIdx.x;
    
                var blockPosInGridY = 0;
                blockPosInGridY = thread.blockIdx.y;
    
                var gridSizeX = 0;
                gridSizeX = thread.gridDim.x;
    
                var gridSizeY = 0;
                gridSizeY = thread.gridDim.y;
    
                var blockSizeX = 0;
                blockSizeX = thread.blockDim.x;
    
                var blockSizeY = 0;
                blockSizeY = thread.blockDim.y;
    
                var threadX = blockSizeX * blockPosInGridX + threadPosInBlockX;
    
                //if i use only one variable, everything is fine:
                var threadY = blockSizeY;
    
                // this calculates just fine
                threadY = blockSizeY * blockPosInGridY + threadPosInBlockY;
    
                // hint: use NSight for Visual Studio and look at the NSight output, 
                // it reports access violations and tells you where...
    
                // if our threadId is within bounds of array size
                // we cause access violation if not
                if (threadId < results.Length)
                    results[threadId] = threadX + threadY;
                            
            }
    
        }
    }
