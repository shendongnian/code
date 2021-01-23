                string outputFile = "output.mp4";
                if(File.Exists(outputFile))
                {
                    File.Delete(outputFile);
                }
                string arguments = "-f dshow -i video=\"screen-capture-recorder\" -video_size 1920x1080 -vcodec libx264 -pix_fmt yuv420p -preset ultrafast " + outputFile;
                //run the process
                Process proc = new Process();
                proc.StartInfo.FileName = "ffmpeg.exe";
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardInput = true;
                proc.ErrorDataReceived += build_ErrorDataReceived;
                proc.OutputDataReceived += build_OutDataReceived;
                proc.EnableRaisingEvents = true;
                proc.Start();
                
                proc.BeginOutputReadLine();
                proc.BeginErrorReadLine();
                await Task.Delay(3000);
                StreamWriter inputWriter = proc.StandardInput;
                inputWriter.WriteLine("q");
                proc.WaitForExit();
                proc.Close();
                inputWriter.Close();
