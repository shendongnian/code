    List<City> cities=new List<City>();
    foreach(String s in File.ReadAllLines(path))
    {
        List<City> cities=new List<City>();
       foreach(String s in File.ReadAllLines(path))
       {
           City temp=new City();
           temp.ZipCode=int.Parse(s.Split(',')[0]);
            temp.Name=s.Split(',')[1];
           cities.Add(temp);
       }
    }
