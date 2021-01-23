    List<Object> existingOnes = new List<Object>();
    var clone = Instantiate(...);
    clone.name= "0001";
    existingOnes.Add(clone);
    var theOne = existingOnes.Where(item 
                 => item.name.Equals("0001").FirstOrDefault();
