    public class ProductList
    {
      IEnumerable<Product> Products {get;set;}
    
        var Validator = new ProductListValidator();
        public bool IsValid
        {
            get
            {
                var res = Validator.Validate(this);
                return res.IsValid;
            }
        }
        public IList<ValidationFailure> ValidationResult
        {
            get
            {
                var res = Validator.Validate(this);
                return res.Errors;
            }
        }
    }
       public class ProductListValidator : AbstractValidator<ProductList>
       {
          public ProductListValidator()
          {
              RuleFor(i => i.Products).Must(i => i.HasAny()).WithMessage("Your Error Meesage");
          }
     
       }
