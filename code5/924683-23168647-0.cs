    string[] txtFiles;
            txtFiles = Directory.GetFiles(txtFileDestination.Text, "*.txt");
            using (StreamWriter writer = new StreamWriter(txtFileDestination.Text + @"\allfiles.txt"))
            {
                for (int i = 0; i < txtFiles.Length; i++)
                {
                    using (StreamReader reader = File.OpenText(txtFiles[i]))
                    {
                        writer.Write(reader.ReadToEnd());
                    }
                }
            }
