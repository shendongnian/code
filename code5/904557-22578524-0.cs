    [TestMethod]
        public void test_validation()
        {
            var sut = new POSViewModel();
            // Set some properties here
            var context = new ValidationContext(sut, null, null);
            var results = new List<ValidationResult>();
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(POSViewModel), typeof(POSViewModel)), typeof(POSViewModel));
            var isModelStateValid = Validator.TryValidateObject(sut, context, results, true);
            // Assert here
        }
