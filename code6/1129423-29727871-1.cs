                List<string> Temp = new List<string>();
                int SkipLinesNum = 8;
                var GetAllFileToVar = File.ReadLines(@"C:\Sahbak\LinesToList.txt").Skip(SkipLinesNum);
                for (int n = 0; n < GetAllFileToVar.Count(); n++)
                {
                    Temp.Add(GetAllFileToVar.ElementAt(0));
                }
