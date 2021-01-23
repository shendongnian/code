    using(TextFieldParser parser = new TextFieldParser(new StreamReader(path)){
        parser.Delimiters = new string [] {","};
        
        while(true){
            String[] pieces = parser.ReadFields();
            if(pieces == null)
                break;
            csvComplete cEve = new csvComplete (pieces[0], pieces[1], pieces[2], pieces[3], pieces[4]);// assign to class cEve
            entries.Add(cEve);
        }
    }
