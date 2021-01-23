    select new
     {
         Firstel = (string)y.Element(ns + "Document").Element(ns+"country"),
         Secondel = (string)y.Element(ns+"Document").Element(ns+"Name"),
     };
    foreach (var item in result){
            if(item.Firstel!=string.empty)
                Console.WriteLine("Country value={0}", item.Firstel);
            if(item.Secondel!=string.empty)
                Console.WriteLine("Name value={0}", item.Secondel);
    } 
