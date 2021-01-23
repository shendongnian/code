    public class PersonVM
    {
      public int Id { get; set; }
      public string FirstName { get; set; }
      public string LastName { get; set; }
      public int[] ReceivedCalls { get; set; } // this will bind to the selected calls
      public MultiSelectList CallList { get; set; } // to display the calls   
    }
