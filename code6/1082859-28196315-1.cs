        public void DoIt()
        {
            // Samplearray of type string
            var typeOfT = typeof(String);
            String[] objectsToValidate = new string[] { "AA", "BB" };
            MethodInfo methodInfo = typeof(ValidatorExtension).GetMethod("ValidateMany");
            MethodInfo genericMethod = methodInfo.MakeGenericMethod(new[] { typeOfT });
            IList<ValidationResult> forTheResult = new List<ValidationResult>();
            genericMethod.Invoke(forTheResult , objectsToValidate);
        }
