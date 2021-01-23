    public static class GPUModuleExtensions
    {
        public static void MyGPULaunch<T1, T2, T3>(
            this ILGPUModule module,
            Action<T1, T2, T3> kernelD, LaunchParam lp,
            T1 arg1, T2 arg2, T3 arg3)
        {
            // get the kernel object by method name
            var kernel = module.GPUEntities.GetKernel(kernelD.Method.Name).Kernel;
            // create parameter list (which is FSharpList)
            var parameterArray = new object[] {arg1, arg2, arg3};
            var parameterList = ListModule.OfArray(parameterArray);
            // use untyped LaunchRaw to launch the kernel
            kernel.LaunchRaw(lp, parameterList);
        }
    }
    
    public class GPUModule : ILGPUModule
    {
        public GPUModule() : base(GPUModuleTarget.DefaultWorker)
        {
        }
    
        [Kernel]
        public void Kernel(deviceptr<int> outputs, int arg1, int arg2)
        {
            var tid = threadIdx.x;
            outputs[tid] = arg1 + arg2;
        }
    
        [Test]
        public void Test()
        {
            const int n = 32;
            var lp = new LaunchParam(1, n);
            using (var outputs = GPUWorker.Malloc<int>(n))
            {
                this.MyGPULaunch(Kernel, lp, outputs.Ptr, 1, 3);
                Console.WriteLine("{0}", (outputs.Gather())[4]);
            }
        }
    }
