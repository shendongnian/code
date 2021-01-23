            var p = new Process
            {
                StartInfo =
                {
                    FileName = "cmd.exe"
                }
            };
            var t = Task.Run(() => p.Start());
            Console.WriteLine("press any key to kill the other app");
            Console.ReadKey();
            if (!p.HasExited)
            {
                p.Kill();
                Console.WriteLine("other app was killed");
            }
            else
            {
                Console.WriteLine("other app was already dead");
            }
            Console.ReadKey();
