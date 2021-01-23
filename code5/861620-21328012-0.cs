            static object _lock = new object();
            public void readFile()
            {
                 lock(_lock)
                 {
                     using(var vsfr = new FSReader((string)path))
                         while (vsfr.EndOfStream == false)
                             PrintLine(vsfr.ReadLine());
                 }
            }
