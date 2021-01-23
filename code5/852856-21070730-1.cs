    [TestClass]
    public class RefectionInValidationTest
    {
        [TestMethod]
        public void GivenAModelWithItemMaxAttributeOnFieldName_WhenValidating_ThenModelClassIsValid()
        {
            //Arange
            var validModelClass = new ModelClass();
            var validations = new Collection<ValidationResult>();
            //Act
            var isValid = Validator.TryValidateObject(validModelClass, new ValidationContext(validModelClass, null, null), validations, true);
            //Assert
            Assert.IsTrue(isValid);
        }
        [TestMethod]
        public void GivenAModelWithItemMaxAttributeOnFieldNotName_WhenValidating_ThenModelClassIsInvalid()
        {
            //Arange
            var invalidaModelClass = new InvalidModelClass();
            var validations = new Collection<ValidationResult>();
            //Act
            var isValid = Validator.TryValidateObject(invalidaModelClass, new ValidationContext(invalidaModelClass, null, null), validations, true);
            //Assert
            Assert.IsFalse(isValid);
        }
    }
    public class ModelClass
    {
        [ItemMaxLength(10)]
        public IDictionary<string, string> Names { get; set; }
    }
    public class InvalidModelClass
    {
        [ItemMaxLength(10)]
        public IDictionary<string, string> NotNames { get; set; }
    }
    public class ItemMaxLengthAttribute : ValidationAttribute
    {
        private readonly int _maxLength = int.MaxValue;
        public ItemMaxLengthAttribute(int maxLength)
        {
            _maxLength = maxLength;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propretyInfo = validationContext.ObjectType.GetProperty(validationContext.MemberName);
            if (propretyInfo.Name == "Names")
                return ValidationResult.Success;
            return new ValidationResult("The property isn't 'Names'");
        }
    }
