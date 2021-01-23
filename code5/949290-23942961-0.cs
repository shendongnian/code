    public JsonResult GetResult(InheritType type){
        typeof(yourClass)
              .GetMethod("GetResultGeneric")
              .MakeGenericMethod(type.SelectedType.GetType())
              .Invoke(yourClass, new object[] {type});
        
    
    }
