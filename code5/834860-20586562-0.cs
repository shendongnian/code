    public class Customer{
        
        public Customer(int id, string name, string email){
        this.Id = id;
        this.Name = name;
        this.Email = email;
        }
          
        public int Id {get; private set;}
        public string Name {get; private set;}
        public string Email{get; private set;}
        public static IEnumerable<Customer> ReadCustomer(){
           
               //Here you read the data from database and add each row to you List of Customer.
        }
    }
