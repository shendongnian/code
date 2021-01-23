     public void ValidateCsv(string fileContents)
     {
         var fileLines = fileContents.Split(
               new string[] { "\r\n", "\n" }, StringSplitOptions.None);
          if (fileLines.Count < 2)
             //fail - no data row.
          ValidateColumnHeader(fileLines[0]);
          ValidateRows(fileLines.Skip(1));
     }
     public bool ValidateColumnHeaders(string header)
     {
          return header.Trim().Replace(' ','').ToLower() == 
             "name,address,age,gender";
     }
     public bool ValidateRows(IEnumerable<string> rows)
     {
          foreach(row in rows)
          {
              var cells = row.Split(',');
               //check if the number of cells is correct
               if (!cells.Length == 4)
                    return false;
               //ensure gender is correct
               if (cells[3] != "M" && cells[3] != "F")
                   return false;
               //perform any additional row checks relevant to your domain
          }
     }
