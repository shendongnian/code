            Process potrace = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = @"C:\potrace-1.11.win64\potrace.exe",
                    Arguments = "C:\\potrace-1.11.win64\\circle.bmp --backend dxf", //DXF
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
               //     RedirectStandardError = Program.IsDebug,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden
                },
                EnableRaisingEvents = false
            };
            StringBuilder svgBuilder = new StringBuilder();
            potrace.OutputDataReceived += (object sender2, DataReceivedEventArgs e2) =>
            {
                svgBuilder.AppendLine(e2.Data);
            };
            /*
            if (Program.IsDebug)
            {
                potrace.ErrorDataReceived += (object sender2, DataReceivedEventArgs e2) =>
                {
                    Console.WriteLine("Error: " + e2.Data);
                };
            }
             */
            potrace.Start();
             /*
              * 
            potrace.BeginOutputReadLine();
            if (Program.IsDebug)
            {
                potrace.BeginErrorReadLine();
            }
            */
            /*
            BinaryWriter writer = new BinaryWriter(potrace.StandardInput.BaseStream);
            // Construct a new image from the GIF file.
            Bitmap bmp2 = new Bitmap(@"C:\Users\Matus\Desktop\potrace-1.11.win64\kruz.bmp");
            bmp2.Save(writer.BaseStream, System.Drawing.Imaging.ImageFormat.Bmp);
            potrace.StandardInput.WriteLine(); //Without this line the input to Potrace won't go through.
             * **/
            potrace.WaitForExit();
