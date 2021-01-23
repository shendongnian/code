    string path = "" <- your path here.
    if (path.EndsWith(".pdf"))
                {
                    if (File.Exists(path))
                    {
                        ProcessStartInfo info = new ProcessStartInfo();
                        info.Verb = "print";
                        info.FileName = path;
                        info.CreateNoWindow = true;
                        info.WindowStyle = ProcessWindowStyle.Hidden;
                        Process p = new Process();
                        p.StartInfo = info;
                        p.Start();
                        p.WaitForInputIdle();
                        System.Threading.Thread.Sleep(3000);
                        if (false == p.CloseMainWindow())
                            p.Kill();
                    }
                }
