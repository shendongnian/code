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
    
                gpu.Launch(blocksPerGrid, threadsPerBlock, "GenerateRipples", dev_results, dev_filled_results);
    
                gpu.CopyFromDevice(dev_results, host_results); 
            }
    
            [Cudafy]
            public static void GenerateRipples(GThread thread, int[] results)
            {
                int threadPosInBlockX = thread.threadIdx.x;
                int threadPosInBlockY = thread.threadIdx.y;
    
                int blockPosInGridX = thread.blockIdx.x;
                int blockPosInGridY = thread.blockIdx.y;
    
                int gridSizeX = thread.gridDim.x;
                int gridSizeY = thread.gridDim.y;
    
                int blockSizeX = thread.blockDim.x;
                int blockSizeY = thread.blockDim.y;
    
                int threadX = blockSizeX * blockPosInGridX + threadPosInBlockX;
    
                //if i use only one variable, everything is fine:
                int threadY = blockSizeY;
    
                //if i add or multiply anything, it cannot compile:
                threadY = blockSizeY * blockPosInGridY + threadPosInBlockY;
    
                results[gridSizeX * blockSizeX * threadY + threadX] = 255;
            }
    
        }
    }
