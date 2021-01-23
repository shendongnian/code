    string str = "John Carter, Mike David, John Edward,";
    string[] names = str.Split(',');
    foreach (string name in names)
    {
        if (name.Equals(""))
            continue;
        ///dbstuff
        ///insert into myTable(ID, Full_Name) values(@ID, @name)
        ///etc, etc
    }
