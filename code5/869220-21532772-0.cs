    public class Customer {
      public string Name { get; set; }
      public Address Address { get; set; }
    }
    public class Address {
     public string Line1 { get; set; }
     public string Line2 { get; set; }
     public string Town { get; set; }
     public string County { get; set; }
     public string Postcode { get; set; }
    }
    public class AddressValidator : AbstractValidator<Address> {
      public AddressValidator() {
        RuleFor(address => address.Postcode).NotNull();
        //etc
      }
    }
    public class CustomerValidator : AbstractValidator<Customer> {
      public CustomerValidator() {
        RuleFor(customer => customer.Name).NotNull();
        RuleFor(customer => customer.Address).SetValidator(new AddressValidator())
      }
