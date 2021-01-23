    Person luca = db.Traverse<Person>(new ORID("#12:0"));
    // luca.Name == "Luca"
    // luca.Owns != null
    // luca.Owns.Count == 1
    // luca.Owns[0].Name == "Ferrari Modena"
    // luca.Owns[0].Owner == luca
    // luca.Lives != null
    // luca.Lives.Name == "UK"
    // luca.Lives.Residents != null
    // luca.Lives.Residents.Count == 2
    // luca.Lives.Residents[0] == luca
    // luca.Lives.Residents[1].Lives.Residents[0] == luca
    // luca.Lives.Residents[1].Owns == null -> because there is no edge to any Car
