        public void PostgreSqlDump(
            string pgDumpPath,
            string outFile,
            string host,
            string port,
            string database,
            string user,
            string password)
        {
            String dumpCommand = pgDumpPath + " -Fc" + " -h " + host + " -p " + port + " -d " + database + " -U " + user + "";
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
                batchContent += "@" + dumpCommand + "  > " + "\"" + outFile + "\"" + "\n";
                File.WriteAllText(
                    batFilePath,
                    batchContent,
                    Encoding.ASCII);
                File.WriteAllText(
                    passFilePath,
                    passFileContent,
                    Encoding.ASCII);
                if (File.Exists(outFile))
                    File.Delete(outFile);
                ProcessStartInfo oInfo = new ProcessStartInfo(batFilePath);
                oInfo.UseShellExecute = false;
                oInfo.CreateNoWindow = true;
                using (Process proc = System.Diagnostics.Process.Start(oInfo))
                {
                    proc.WaitForExit();
                    proc.Close();
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
