        public void ExistsInCollectionValidatorTest()
        {
            var track = new Track()
            {
                puic = "p1"
            };
            var sut = new ExistsInCollectionValidator<Track>();
            // Build PropertyValidator.Validate() parameter
            var selector = ValidatorOptions.ValidatorSelectors.DefaultValidatorSelectorFactory();
            var context = new ValidationContext(track, new PropertyChain(), selector);
            var propertyValidatorContext = new PropertyValidatorContext(context, PropertyRule.Create<Track,string>(t => t.puic), "puic");
            var results = sut.Validate(propertyValidatorContext);
            // Assertion..
        }
