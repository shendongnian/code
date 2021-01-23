    public class RuleViolation
    {
        public string Property {get; set;}
        public string Message {get; set;}
    }
    public class Program
    {
        public static List<RuleViolation> GetRuleViolations(string[] parameters)
        {
            List<RuleViolation> validations = new List<RuleViolation>();
            int input1;
            
            if(!int.TryParse(parameters[0], out input1))
            {
                validations.Add(new RuleViolation{Message ="Input1 must be integer.", Property = "input1"});
            }
            //more validation
            return validations;
        }
        public static void Main(string[] parameters)
        {
            var validations = GetRuleViolations(parameters);
            if(validations.Any())
            {
                validations.ForEach(x=> Console.WriteLine(x.Message));
                return;
            }
            
            //after all your business logic are ok, then you can go to persistence layer to hit the database.
            using (var context  = new entityTestEntities2())
            {
                try
                {
                    var allCustomers = context.setcust(null, input1);
                }
                catch(SqlException exc)
                {
                    //here you might still get some exceptions but not about validation.
                    ExceptionManager.Log(exc);
                    
                    //sometimes you may want to throw the exception to upper layers for handle it better over there!
                    throw;
                }
            }
        }
    }
