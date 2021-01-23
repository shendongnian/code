    public class Result
    {
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string Label { get { return FirstName + LastName } }
    }
