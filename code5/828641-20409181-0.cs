       // in CatInfoType class
       public CatInfoType(string name, string id)
       {
             Name = name;
             Id = id;
       }
       Select(c => new CatInfoType(c.Name, c.Id))
