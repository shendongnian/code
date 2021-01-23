    public List<string> getListOfCommands()
            {
                List<string> commandList = new List<string>();
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.ShowDialog();
                object fileName = ofd.FileName;
                Word.Application wapp = GetWordApp();
                var document = wapp.Documents.Open(fileName);
                var range1 = document.Range();
                var range2 = document.Range();
                string findTextStart = "!#"; //Commands tagStart
                string findTextEnd = "#!"; //Commands tagEnd
                wapp.Selection.Find.ClearFormatting();
                range1.Find.Execute(findTextStart);
                while (range1.Find.Found)
                {
                    if (range1.Text.Contains(findTextStart))
                    {
                        range2.Find.Execute(findTextEnd);
                        if (range1.End < range2.Start)
                        {
                            Word.Range temprange = document.Range(range1.End, range2.Start);
                            commandList.Add(temprange.Text);
                        }
                        else
                        {
                            commandList.Add("Error - Are you missing a start or end tag?");
                        }
                    }
                    range1.Find.Execute(findTextStart);
                }
                return commandList;
            }
