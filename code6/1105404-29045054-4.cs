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
                gpu.Set<int>(dev_results);
    
                // Or fill your array with values first and then
                for (int i = 0; i < N; i++) host_results[i] = i * 3;
    
                // Copy array with ints to device
                //var dev_filled_results = gpu.CopyToDevice(host_results);
    
                // 64*16 = 1024 threads per block (which is max for sm_30)
                dim3 threadsPerBlock = new dim3(64, 16);    
    
                // 8*8 = 64 blocks per grid, 1024 threads per block = kernel launched 65536 times
                dim3 blocksPerGrid = new dim3(8, 8); 
                
                //var threadsPerBlock = 1024; // this will only give you blockDim.x = 1024, .y = 0, .z = 0
                //var blocksPerGrid = 1;      // just for show
    
                gpu.Launch(blocksPerGrid, threadsPerBlock, "GenerateRipples", dev_results);
    
                gpu.CopyFromDevice(dev_results, host_results); 
    
                // Test our results
                for (int index = 0; index < N; index++)
                    if (host_results[index] != index)
                        throw new Exception("Check your indexing math, genius!!!");
            }
    
            [Cudafy]
            public static void GenerateRipples(GThread thread, int[] results)
            {
                var blockSize = thread.blockDim.x * thread.blockDim.y;
    
                var offsetToGridY = blockSize * thread.gridDim.x;
    
                // This took me a few tries, I've never used 4 dimensions into a 1D array beofre :)
    
                var tid = thread.blockIdx.y * offsetToGridY +       // each Grid Y is 8192 in size
                          thread.blockIdx.x * blockSize +           // each Grid X is 1024 in size
                          thread.threadIdx.y * thread.blockDim.x +  // each Block Y is 64 in size
                          thread.threadIdx.x;                       // index into block
    
    
                var threadPosInBlockX = thread.threadIdx.x;
    
                var threadPosInBlockY = thread.threadIdx.y;
    
                var blockPosInGridX = thread.blockIdx.x;
    
                var blockPosInGridY = thread.blockIdx.y;
    
                var gridSizeX = thread.gridDim.x;
    
                var gridSizeY = thread.gridDim.y;
    
                var blockSizeX = thread.blockDim.x;
    
                var blockSizeY = thread.blockDim.y;
    
                // this is your code, see how I calculate the actual thread ID above!
                var threadX = blockSizeX * blockPosInGridX + threadPosInBlockX;
    
                //if i use only one variable, everything is fine:
                var threadY = blockSizeY;
    
                // this calculates just fine
                threadY = blockSizeY * blockPosInGridY + threadPosInBlockY;
    
                // hint: use NSight for Visual Studio and look at the NSight output, 
                // it reports access violations and tells you where...
    
                // if our threadId is within bounds of array size
                // we cause access violation if not
                // (class constants are automatically passed to kernels)
                if (tid < N)
                    results[tid] = tid;
                            
            }
    
        }
    }
