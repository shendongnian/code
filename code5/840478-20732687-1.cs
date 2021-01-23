    while ((map = sr.ReadLine()) != null)
    {
         string[] split = map.Split(','); 
         //First Hey would be split[0], second Hey would be split[1]
         maps.Add(split[0].Trim());
         maps2.Add(split[1].Trim());
    }
