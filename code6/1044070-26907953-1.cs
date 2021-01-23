    while (true)
                {
                    Console.WriteLine("Komut giriniz.");
                    string komut = Console.ReadLine();
                    System.Diagnostics.Process process = new System.Diagnostics.Process();
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    //startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    startInfo.FileName = "cmd.exe";
                    startInfo.Arguments = "/C" + komut;
                    startInfo.RedirectStandardOutput = true;
                    startInfo.UseShellExecute = false;
                    process.StartInfo = startInfo;
                    Console.WriteLine(process.Start());
                    string line = "";
                    while (!process.StandardOutput.EndOfStream)
                    {
                        line = line + System.Environment.NewLine + process.StandardOutput.ReadLine();
                        // do something with line
                    }
                    Console.WriteLine(line);
                    Console.ReadLine();
                }
