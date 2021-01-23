    var obj = new General<int>();
    var isGeneral = 
    typeof(General<>).IsAssignableFrom(obj.GetType().GetGenericTypeDefinition());
    // isGeneral = true
  
