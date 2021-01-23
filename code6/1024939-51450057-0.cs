    using System;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    
    namespace ArrayConverter {
       public class Benchmark {
            [Params(10, 100, 1000, 10000)] 
            public int size;
    
            public double[][] data;
    
            [GlobalSetup]
            public void Setup() {
                var rnd = new Random();
    
                data = new double[size][];
                for (var i = 0; i < size; i++) {
                    data[i] = new double[size];
                    for (var j = 0; j < size; j++) {
                        data[i][j] = rnd.NextDouble();
                    }
                }
            }
            
            [Benchmark]
            public void ComputeTo2D() {
                var output = To2D(data);
            }
    
           [Benchmark]
           public void ComputeTo2DFast() {
               var output = To2DFast(data);
           }
    
           public static T[,] To2DFast<T>(T[][] source) where T : unmanaged{
               var dataOut = new T[source.Length, source.Length];
               var assertLength = source[0].Length;
               
               unsafe {
                   for (var i=0; i<source.Length; i++){
                       if (source[i].Length != assertLength) {
                           throw new InvalidOperationException("The given jagged array is not rectangular.");
                       }
                       
                       fixed (T* pDataIn = source[i]) {
                           fixed (T* pDataOut = &dataOut[i,0]) {
                               CopyBlockHelper.SmartCopy<T>(pDataOut, pDataIn, assertLength);
                           }
                       }
                   }
               }
    
               return dataOut;
           }
    
            public static T[,] To2D<T>(T[][] source) {
                try {
                    var FirstDim = source.Length;
                    var SecondDim =
                        source.GroupBy(row => row.Length).Single()
                            .Key; // throws InvalidOperationException if source is not rectangular
    
                    var result = new T[FirstDim, SecondDim];
                    for (var i = 0; i < FirstDim; ++i)
                    for (var j = 0; j < SecondDim; ++j)
                        result[i, j] = source[i][j];
    
                    return result;
                }
                catch (InvalidOperationException) {
                    throw new InvalidOperationException("The given jagged array is not rectangular.");
                }
            }
        }
    
        public class Programm {
            public static void Main(string[] args) {
                BenchmarkRunner.Run<Benchmark>();
    //            var rnd = new Random();
    //            
    //            var size = 100;
    //            var data = new double[size][];
    //            for (var i = 0; i < size; i++) {
    //                data[i] = new double[size];
    //                for (var j = 0; j < size; j++) {
    //                    data[i][j] = rnd.NextDouble();
    //                }
    //            }
    //
    //            var outSafe = Benchmark.To2D(data);
    //            var outFast = Benchmark.To2DFast(data);
    //
    //            for (var i = 0; i < outSafe.GetLength(0); i++) {
    //                for (var j = 0; j < outSafe.GetLength(1); j++) {
    //                    if (outSafe[i, j] != outFast[i, j]) {
    //                        Console.WriteLine("Error at: {0}, {1}", i, j);
    //                    }
    //                }
    //            }
    //
    //            Console.WriteLine("All Good!");
    
            }
        }
    }
