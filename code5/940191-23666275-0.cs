    var userType = typeof(User);
    var properties = userType
                    .GetProperties()
                    .Where(x => x.Name.StartsWith("Value")).ToList());
    foreach (var user in LiUsers)
    {
        var property  = properties.FirstOrDefault(x => (int)x.GetValue(user) == 100);
        if(property != null)
        {
            string name = property.Name;
        }
    }
