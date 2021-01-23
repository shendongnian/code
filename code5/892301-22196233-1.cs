    var splitArray = "Joe Thompson (234DerX)".Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    var id = splitArray.Last().Trim(new char['(',')']);
    var name = splitArray[0] + " " + splitArray[splitArray.Length - 2];
        
    var person = new Person();
    person.Id = id;
    
    person.Name = name;
