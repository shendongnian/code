    var result = myList
        .AsEnumerable()
        .Where(f => {
             var age = DateHelper.RetrieveAge(f.Birthdate);
             return age >= 20 && age <= 40; // <<== Here
        }).Select(x => new Person {
             Name = x.Name, Id = x.Id, Alias = x.Alias }
        ).ToList();
