    namespace Winpro
    {
    public partial class Customer
    {
        public Customer(DateTime parameterAdded)
         : this() //call the default constructor
        {
            this.Added = parameterAdded; //DateTime.Now;
        }
