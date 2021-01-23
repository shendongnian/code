    private void SaveCustomerChanges()
    {
       //Could use Automapper to handle mapping for you.
       CurrentCustomer.FirstName = this.FirstName;
       CurrentCustomer.LastName = this.LastName;
       dbContext.SaveChanges(); //dbContext will be named diff for you
    }
