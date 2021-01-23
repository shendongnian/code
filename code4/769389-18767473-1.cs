        public static void GeneratePdf(Stream html, Stream pdf) 
        {
            Process process;
            StreamWriter stdin;
            var psi = new ProcessStartInfo();
            psi.FileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Lib", "wkhtmltopdf.exe");
            psi.WorkingDirectory = Path.GetDirectoryName(psi.FileName);
            // run the conversion utility
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            
            psi.Arguments = "-q -n --disable-smart-shrinking - -";
            process = Process.Start(psi);
            try
            {
                stdin = process.StandardInput;
                stdin.AutoFlush = true;
                //stdin.Write(html.ReadToEnd());
                stdin.Write(new StreamReader(html).ReadToEnd());
                stdin.Dispose();
                process.StandardOutput.BaseStream.CopyTo(pdf);
                process.StandardOutput.Close();
                pdf.Position = 0;
                
                process.WaitForExit(10000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                process.Dispose();
            }
        }
