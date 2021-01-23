    string [] File1Lines = File.ReadAllLines(pathOfFileA);
          string [] File2Lines = File.ReadAllLines(pathOfFileB);
          List<string> NewLines = new List<string>();
          for (int lineNum = 0; lineNo < File1Lines.Length; lineNo++)
          {
            if(!String.IsNullOrEmpty(File1Lines[lineNum]) 
     String.IsNullOrEmpty(File2Lines[lineNo]))
            {
              if(String.Compare(File1Lines[lineNo], File2Lines[lineNo]) != 0)
                NewLines.Add(File2Lines[lineNo]) ;
            }
            else if (!String.IsNullOrEmpty(File1Lines[lineNo]))
            {
            }
            else
            {
              NewLines.Add(File2Lines[lineNo]);
            }
          }
          if (NewLines.Count > 0)
          {
            File.WriteAllLines(newfilepath, NewLines);
          }
