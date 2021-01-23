        static void Main(string[] args)
        {
            using (var writefile = new FileWriter(@"writefile.txt"))
            {
                Action<string> readAndWrite= fn =>
                {
                    using (var fr = new FileReader(fn))
                    {
                        while (!fr.IsFinished)
                        {
                            writefile.writeLine(fr.ReadLine());
                        }
                    }
                };
                AsyncCallback callBack = ar => { };
                var ar1 = readAndWrite.BeginInvoke(@"file1.txt", callBack, null);
                var ar2 = readAndWrite.BeginInvoke(@"file2.txt", callBack, null);
                var ar3 = readAndWrite.BeginInvoke(@"file3.txt", callBack, null);
                WaitHandle.WaitAll(new[]
                {
                        ar1.AsyncWaitHandle,
                        ar2.AsyncWaitHandle,
                        ar3.AsyncWaitHandle,
                });
            }
        }
    }
