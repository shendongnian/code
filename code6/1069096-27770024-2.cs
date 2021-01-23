       List<dynamic> list = new List<dynamic>();
       list.Add(new
       {
             name = "john", 
             pet = new 
             { 
                  name = "doggy"
             }
       });
       string csv = CsvSerializer.SerializeToCsv(list);
