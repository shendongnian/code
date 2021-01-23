        internal void ReadText()
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;//This causes the folder to begin at the root folder or your documents
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath, "*.html", SearchOption.AllDirectories);//change this to specify file type
                    SaveFileDialog sfd = new SaveFileDialog();// Create save the CSV
                    //sfd.Filter = "Text File|*.txt";// filters for text files only
                    sfd.FileName = "Html Output.txt";
                    sfd.Title = "Save Text File";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        string path = sfd.FileName;
                        using (StreamWriter bw = new StreamWriter(File.Create(path)))
                        {
                            foreach (string f in files)
                            {
                                
                                var html = new HtmlAgilityPack.HtmlDocument();
                                html.Load(f);
                                foreach (var table in html.DocumentNode.SelectNodes("//table").Skip(1).Take(1))//specify which tag your looking for
                                {
                                    foreach (var td in table.SelectNodes("//td"))// this is the sub tag
                                    {
                                        bw.WriteLine(td.InnerText);// this will make a text fill of what you are looking for in the HTML files
                                    }
                                }
                                
                            }//ends loop of files
                            bw.Flush();
                            bw.Close();
                        }
                    }
                    MessageBox.Show("Files found: " + files.Count<string>().ToString());
                }
            }
            catch (UnauthorizedAccessException UAEx)
            {
                MessageBox.Show(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                MessageBox.Show(PathEx.Message);
            }
        }//method ends
    }
