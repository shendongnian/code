      if (f.Extension.ToLower() == ".docx")
                    {
                        using (ZipFile zip = ZipFile.Read(file))
                        {
                            ZipEntry a = zip[@"word\document.xml"];
                            a.Extract(ms);
                        }
                        ms.Position = 0;
                        var sr = new StreamReader(ms);
                        var myStr = sr.ReadToEnd();
                        if (myStr.Contains(textBox3.Text))
                        {
                            textBox1.AppendText(file + "\r\n");
                            break;                    
                        }
                    }
