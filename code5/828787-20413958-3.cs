    public class GetSet : ISet, IGet
    {
        public string Value { get; set; }
    }
    ...
    getSet.Value = "This is a test";
    Debug.Print(getSet.Value); //Prints "This is a test"
