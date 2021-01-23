     var csvFactory = new CsvFactory();
     using(var parser = csvFactory.CreateParser(reader, DefaultCsvConfiguration)){
    
        while(true){
           var arrayResult = parser.Read();
           if(arrayResult == null){
              break; //end of file
           }
           else{
              //DO THINGS WITH arrayResult
           }
        }
    }
