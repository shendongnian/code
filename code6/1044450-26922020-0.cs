    class ViewModel {
    public string prop1 {get; set;}
    public string prop2 {get; set;}
    List<string> prop3 {get; set;}
        ..........  // more properties
    public ViewModel() {
        prop1 = DataModel.field1
        prop2 = DataModel.field2;
        prop3 = UtilityClass.complexFunction();
       ......
    }
