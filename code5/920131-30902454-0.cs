        public void PostgreSqlDump(
            string pgDumpPath,
            string outFile,
            string host,
            string port,
            string database,
            string user,
            string password)
        {
            String dumpCommand = pgDumpPath + " -h " + host + " -p " + port + " -d " + database + " -U " + user + "";
            String passFileContent = "" + host + ":" + port + ":" + database + ":" + user + ":" + password + "";
            String batFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".bat");
            String passFilePath = Path.Combine(
                Path.GetTempPath(),
                Guid.NewGuid().ToString() + ".conf");
            try
            {
                String batchContent = "";
                batchContent += "@" + "set PGPASSFILE=" + passFilePath + "\n";
                batchContent += "@" + dumpCommand + "" + "\n";
                File.WriteAllText(
                    batFilePath,
                    batchContent,
                    new UTF8Encoding(false));
                File.WriteAllText(
                    passFilePath,
                    passFileContent,
                    new UTF8Encoding(false));
                ProcessStartInfo oInfo = new ProcessStartInfo(batFilePath);
                oInfo.UseShellExecute = false;
                oInfo.CreateNoWindow = true;
                oInfo.RedirectStandardOutput = true;
                //string output = null;
                StreamReader stOutput = null;
                try
                {
                    if (File.Exists(outFile))
                        File.Delete(outFile);
                    using (StreamWriter fs = new StreamWriter(outFile))
                    {
                        using (Process proc = System.Diagnostics.Process.Start(oInfo))
                        {
                            stOutput = proc.StandardOutput;
                            char[] chars = new char[1024];
                            while (true)
                            {
                                var count = stOutput.Read(
                                    chars,
                                    0,
                                    chars.Length);
                                if (count <= 0)
                                    break;
                                fs.Write(
                                    chars,
                                    0,
                                    count);
                            }
                            proc.WaitForExit();
                            proc.Close();
                        }
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (stOutput != null)
                    {
                        stOutput.Close();
                        stOutput.Dispose();
                    }
                }
            }
            finally
            {
                if (File.Exists(batFilePath))
                    File.Delete(batFilePath);
                if (File.Exists(passFilePath))
                    File.Delete(passFilePath);
            }
        }
