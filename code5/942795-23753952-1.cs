       List<Information> Informations = new List<Information>();
        Information infoObj = new Information();
        infoObj.FromValue = 10;
        infoObj.ToValue = 20;
        infoObj.Info = "TX";
        Informations.Add(infoObj);
        Information infoObj2 = new Information();
        infoObj2.FromValue = 24;
        infoObj2.ToValue = 56;
        infoObj2.Info = "NY";
        Informations.Add(infoObj);
        //passing sample input which lies between fromvalue and tovalue
        int sampleInput = 15;
        var result = Informations.FirstOrDefault(x => x.FromValue < sampleInput && sampleInput < x.ToValue);
   
