        using (StreamReader file = new StreamReader(fileName))
            {
                while (file.Peek() >= 0)
                {
                    string line = file.ReadLine();
                    char[] charSeparators = new char[] { '§' };
                    string[] parts = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (PersonId personids in PersonIdDetails)
                    {
                        personids.ChildrenVisualisation.Clear();
                        foreach (PersonId personidchildren in personids.Children)
                        {
                           if(parts.Length > 3)//Only if you want to save lines with all parts but you can create an else clause for other lines with 1 or 2 parts depending on the length
                           {
                            personidchildren.FirstName = parts[1];
                            personidchildren.ID = parts[2];
                            personidchildren.Status = parts[3];
                           
                            personids.ChildrenVisualisation.Add(personidchildren);
                           }
                        }
                    }                             
                }
            }
