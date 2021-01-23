            foreach (var line in File.ReadAllLines(fileName).Where(l => !string.IsNullOrWhiteSpace(l))
            {
               char[] charSeparators = new char[] { '§' };
               string[] parts = line.Split(charSeparators, StringSplitOptions.RemoveEmptyEntries);
               foreach (PersonId personids in PersonIdDetails)
               {
                 personids.ChildrenVisualisation.Clear();
          
                 foreach (PersonId personidchildren in personids.Children)
                 {
                   personidchildren.FirstName = parts[1];
                   personidchildren.ID = parts[2];
                   personidchildren.Status = parts[3];
                   personids.ChildrenVisualisation.Add(personidchildren);
                 }
               }
             }
