                List<string> Temp = new List<string>();
                var GetAllFileToVar= File.ReadLines(@"C:\Sahbak\LinesToList.txt").ToList();
                for (int n = 8; n < GetAllFileToVar.Count; i++)
                {
                    Temp.Add(GetAllFileToVar.ElementAt(0));
                }
