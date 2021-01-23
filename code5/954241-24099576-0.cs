                using (StreamReader sr = File.OpenText(this.CsvPath))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        splittedLine = line.Split(new string[] { this.Separator }, StringSplitOptions.None);
                        if (iLine == 0 && this.HasHeader)
                            // header line
                            this.Header = splittedLine;
                        else
                            this.Lines.Add(splittedLine);
                        iLine++;
                    }
                }
