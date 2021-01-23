    dynamic dyn = DynamicJson.Deserialize(json);
    string id = dyn.Id;
    string name = dyn.Name;
    string dob = dyn.DateOfBirth;
    "DynamicJson: {0}, {1}, {2}".Print(id, name, dob);
