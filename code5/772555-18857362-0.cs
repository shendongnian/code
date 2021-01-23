    var lstFieldNames = typeof(ClassA).GetProperties(
           BindingFlags.Public | BindingFlags.Instance)
           .Select(p=>p.Name).ToList()
    
    var intersect = lstFieldName.Intersect(lstNames);
    var type = typeof(ClassA);
    var myObject = new ClassA(); // or any other object you want its properties values
    var values = intersect.Select(p => new {
               Name = p,
               Value = type
                      .GetProperty(p, System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                      .GetValue(myObject, null)
               });
