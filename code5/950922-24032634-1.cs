    public abstract class Policy
    {
       public int Id { get; set; }
       public string PolicyNumber { get; set; }
    }
    
    public class InsurancePolicy : Policy
    {
    }
    
    public class CarPolicy : Policy
    {
    }
