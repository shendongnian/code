     for (int i = 1; i < lvTextData.Length; i++)
     {
         // removes redundant whitespaces
         string removedWhitespaces = Regex.Replace(lvTextData[i], "\\s+", " ");
         // splits the string
         string[] splitArray = removedWhitespaces.Split(' ');
         // [0]: 01-29-15
         // [1]: 04:04AM
         // [2]: 505758360
         // [3]: examplefilename1.zip
         // do some kind of length checking here
         if(splitArray.Length == dtTextData.Columns.Count) 
         { 
             dtTextData.Rows.Add(splitArray);
         }
     }
