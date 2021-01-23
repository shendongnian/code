    public enum PartyRoleTypeEnum
    {
        Stdudent =20,
        Teacher =21,
        Manager =22
    }
    //--------
    List<int> result = Enum.GetValues(typeof(PartyRoleTypeEnum)).Cast<int>().ToList();
    //--------
    Console.WriteLine(result.Count); //Prints 3
    //--------
    //Prints 20,21,22
    foreach(var item in result)
    {
        Console.WriteLine(item);
    }
    //-------- 
