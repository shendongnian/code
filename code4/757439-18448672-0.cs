    public class SomeClass
    {
        [DataType(DataType.MultilineText)]
        public string Name { get; set; }
    }
    
    @Html.EditorFor(x => x.Name)
