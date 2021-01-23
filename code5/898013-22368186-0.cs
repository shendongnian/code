      List<string> elements = new List<string>();
        for(int i=0; i< CsvValues.length-1; ++i) 
        {
            elements.Add(new wsSample()
            {
                id = CsvValues[i]
                name = CsvValues[i+1]
            });
            i= i+2;
        }
