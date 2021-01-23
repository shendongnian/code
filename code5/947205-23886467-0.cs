    // Initially, I would get a list of all objectB's in the lists of objectB that
    // are contained in the Dictionary values.
    List<ObjectB> objectsB =  objectBDictionary.Select(x=>x.Value)
                                               .SelectMany(y=>y);
              
    // Then, I would make the join.
    var result = from a in objectListA
                 join b in objectsB
                 on new { a.id, a.name } equals { b.id, b.name }
                 select new 
                 {
                     Id = a.id,
                     Name = a.name,
                     Height = a.height,
                     Weight = a.weight,
                     Address = b.address,
                     Email = b.email
                 };
