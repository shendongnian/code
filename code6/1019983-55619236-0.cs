    public class MyClass
    {
          public DateTime Date { get; set; } // You're saving this property in the database
          public bool IsLate => Date < DateTime.Today; // This property is not be saving, and probably is the cause of your exception
    }
