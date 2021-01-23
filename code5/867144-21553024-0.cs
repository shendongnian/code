       using Microsoft.Practices.EnterpriseLibrary.Validation;
    using Microsoft.Practices.EnterpriseLibrary.Validation.Validators;
    public class Customer
    {
      [StringLengthValidator(0, 20)]
      public string CustomerName;
        
      public Customer(string customerName)
      {
        this.CustomerName = customerName;
      }
    }
    
    public class MyExample
    {
      private ValidatorFactory factory;
    
      public MyExample(ValidatorFactory valFactory)
      {
        factory = valFactory;
      }
    
      public void MyMethod()
      {
        Customer myCustomer = new Customer("A name that is too long");
        Validator<Customer> customerValidator 
                            = factory.CreateValidator<Customer>();
    
        // Validate the instance to obtain a collection of validation errors.
        ValidationResults r = customerValidator.Validate(myCustomer);
        if (!r.IsValid)
        {
          throw new InvalidOperationException("Validation error found.");
        }
      }
    }
