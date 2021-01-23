            StreamReader fileIn = new StreamReader(path);
            //Read the file
            while (!fileIn.EndOfStream)
            {
               String line = fileIn.ReadLine();
               String[] pieces = line.Split(',');
               if (pieces.Length == 5)
               {
                   // Exactly 5 fields.   
                   csvComplete cEve = new csvComplete (pieces[0], pieces[1], pieces[2], pieces[3], pieces[4]);// assign to class cEve
               }
               else if (pieces.Length == 6)
               {
                   // Exactly 6 fields. We'll assume fields 1 and 2 should combine for currency string.
                   csvComplete cEve = new csvComplete (pieces[0], pieces[1] + "," + pieces[2], pieces[3], pieces[4], pieces[5], pieces[6]);// assign to class cEve
               }
               else
               {
                   // ?
               }
               entries.Add(cEve);
    
            }
