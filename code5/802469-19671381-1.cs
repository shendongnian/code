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
                        
            if (cells.Length == 1)
            {
                cells = new[] { cells[0], cells[0] };
            }
            // ...
        }
    }
