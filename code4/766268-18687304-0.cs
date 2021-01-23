    var obj = new General<int>();
    var isGeneral = 
    obj.GetType().IsGenericType &&  
    typeof(General<>).IsAssignableFrom(obj.GetType().GetGenericTypeDefinition());
    // isGeneral = true
  
