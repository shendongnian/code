    using System;
    using System.Diagnostics;
    namespace ConsoleExperiments
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                GenerateGarbageNondisposable();
                GenerateGarbage();
                GenerateGarbageWithFinalizers();
                GenerateGarbageFinalizing();
                var sw = new Stopwatch();
                const int garbageCount = 100_000_000;
                for (var repeats = 0; repeats < 4; ++repeats)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    sw.Restart();
                    for (var i = 0; i < garbageCount; ++i)
                        GenerateGarbageNondisposable();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    Console.WriteLine("Non-disposable: " + sw.ElapsedMilliseconds.ToString());
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    sw.Restart();
                    for (var i = 0; i < garbageCount; ++i)
                        GenerateGarbage();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    Console.WriteLine("Without finalizers: " + sw.ElapsedMilliseconds.ToString());
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    sw.Restart();
                    for (var i = 0; i < garbageCount; ++i)
                        GenerateGarbageWithFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    Console.WriteLine("Suppressed: " + sw.ElapsedMilliseconds.ToString());
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    sw.Restart();
                    for (var i = 0; i < garbageCount; ++i)
                        GenerateGarbageFinalizing();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    Console.WriteLine("Finalizing: " + sw.ElapsedMilliseconds.ToString());
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
            private static void GenerateGarbageNondisposable()
            {
                var bla = new NondisposableClass();
            }
            private static void GenerateGarbage()
            {
                var bla = new UnfinalizedClass();
                bla.Dispose();
            }
            private static void GenerateGarbageWithFinalizers()
            {
                var bla = new FinalizedClass();
                bla.Dispose();
            }
            private static void GenerateGarbageFinalizing()
            {
                var bla = new FinalizedClass();
            }
            private class NondisposableClass
            {
                private bool disposedValue = false;
            }
            private class UnfinalizedClass : IDisposable
            {
                private bool disposedValue = false;
                protected virtual void Dispose(bool disposing)
                {
                    if (!disposedValue)
                    {
                        if (disposing)
                        {
                        }
                        disposedValue = true;
                    }
                }
                public void Dispose()
                {
                    Dispose(true);
                }
            }
            private class FinalizedClass : IDisposable
            {
                private bool disposedValue = false;
                protected virtual void Dispose(bool disposing)
                {
                    if (!disposedValue)
                    {
                        if (disposing)
                        {
                        }
                        disposedValue = true;
                    }
                }
                ~FinalizedClass()
                {
                    Dispose(false);
                }
                public void Dispose()
                {
                    Dispose(true);
                    GC.SuppressFinalize(this);
                }
            }
        }
    }
