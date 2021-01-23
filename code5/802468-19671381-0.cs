    var s = 
    @"61663254
    61663236-61663250
    61663254-61663280
    61663254
    61663254-61663280";
    
    using (var stringReader = new StringReader(s))
    {
        string line;
    
        while ((line = stringReader.ReadLine()) != null)
        {
            var cells = line.Split('-');      
            var cell0 = cells[0];    
            string cell1 = null;
                        
            if (cells.Length > 1)
            {
                cell1 = cells[1];
            }
            // ...
        }
    }
