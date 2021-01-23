    class Program
    {
        static void Main()
        {
            // Define some test data by 5i + 3i^2. The plan is to let cminpack figure out
            // the values 5 and 3.
            var data = Enumerable.Range(0, 20)
                .Select(i => 5 * i + 3 * Math.Pow(i, 2))
                .ToList();
            CminpackFuncMn residuals = (p, m, n, x, fvec, iflag) =>
            {
                unsafe
                {
                    // Update fvec with the values of the residuals x[0]*i + x[1]*i^2 - data[i].
                    var fvecPtr = (double*)fvec;
                    var xPtr = (double*)x;
                    for (var i = 0; i < m; i++)
                        *(fvecPtr + i) = *xPtr * i + *(xPtr + 1) * Math.Pow(i, 2) - data[i];
                }
                return 0;
            };
            // Define an initial (bad) guess for the value of the parameters x.
            double[] parameters = { 2d, 2d };
            var numParameters = parameters.Length;
            var numResiduals = data.Count;
            var lwa = numResiduals * numParameters + 5 * numParameters + numResiduals;
            // Call cminpack
            var info = lmdif1(
                fcn: residuals,
                p: IntPtr.Zero,
                m: numResiduals,
                n: numParameters,
                x: parameters,
                fVec: new double[numResiduals],
                tol: 0.00001,
                iwa: new int[numParameters],
                wa: new double[lwa],
                lwa: lwa);
            // parameters now contains { 5, 3 }.
            Console.WriteLine($"Return value: {info}, x: {string.Join(", ", parameters)}");
        }
        [DllImport("cminpack_dll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int lmdif1(CminpackFuncMn fcn, IntPtr p, int m, int n, double[] x,
            double[] fVec, double tol, int[] iwa, double[] wa, int lwa);
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int CminpackFuncMn(IntPtr p, int m, int n, IntPtr x, IntPtr fvec, int iflag);
    }
