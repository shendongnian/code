                if (flag)
                        {
                            db.FbDocuments.Add(fbDocument);
                            db.SaveChanges();
                            var workingDirectory = WebConfigurationManager.AppSettings["MystemDirectory"];
                            System.IO.File.WriteAllText(workingDirectory + @"\input.txt", fbDocument.Title);
                            Process process = new Process();
                            ProcessStartInfo processStartInfo = new ProcessStartInfo();
                            processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            processStartInfo.FileName = "mystem.exe";
                            processStartInfo.WorkingDirectory = workingDirectory;
                            processStartInfo.Arguments = "--format json input.txt output.txt";
                            process.StartInfo = processStartInfo;
                            process.Start();
                            string text = System.IO.File.ReadAllText(workingDirectory + @"\output.txt");
                            var jsSerializer = new JavaScriptSerializer();
                            var jsonCleanText = jsSerializer.Deserialize<CleanText>(text);
                            var fbToUpdate = db.FbDocuments.FirstOrDefault(x => x.Id == fbDocument.Id);
                            fbToUpdate.CleanText = jsonCleanText.ToString();
                            db.SaveChanges();
                        }
