    static class Program
    {
        [STAThread()]
        static void Main(string[] args)
        {
            const int N=10000;
            double t1, t2;
            {
                var array=new Int16[N, N];
                t1=ClockIt(() =>
                {
                    for (int i=0; i<N; i++)
                    {
                        for (int j=0; j<N; j++)
                        {
                            array[i, j]=32767;
                        }
                    }
                    var bytes=new byte[sizeof(Int16)*array.Length];
                    Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);
                    Clipboard.SetData(DataFormats.Serializable, bytes);
                });
            }
            {
                var array=new Int16[N* N];
                t2=ClockIt(() =>
                {
                    for (int i=0; i<N; i++)
                    {
                        for (int j=0; j<N; j++)
                        {
                            array[N*i+j]=32767;
                        }
                    }
                    var bytes=new byte[sizeof(Int16)*array.Length];
                    Buffer.BlockCopy(array, 0, bytes, 0, bytes.Length);
                    Clipboard.SetData(DataFormats.Serializable, bytes);
                });
            }
            
            Console.WriteLine(string.Format("t1={0}, t2={1}",t1, t2));
        }
        public static double ClockIt(this Action test)
        {
            var sw=Stopwatch.StartNew();
            test();
            sw.Stop();
            return sw.Elapsed.TotalSeconds;
        }
    }
