    //populate IEnumerable<dynamic> people1
    //populate List<dynamic> people2
    
    List<dynamic> people3 = new List<dynamic>();
    
    foreach (var person in people1)
       if(people2.Exists(x=>x.FirstName==person.FirstName)
          people3.Add(person);
    
    people1 = people3;
