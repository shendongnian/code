    Dictionary<string, object> findValues = new Dictionary<string, object>();
    findValues.Add("Name", "Tom");
    findValues.Add("Age", 4);
    var list1 = db.Find<Person>(findValues); // Returns a list of persons that includes the find values.
    var list2 = db.Find<Person>() // Returns all persons in the database.
