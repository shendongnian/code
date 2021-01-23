    public static class Validation
    {
        public void ThrowIfAgeInvalid(string ageStr)
        {
            int age;
            try
            {
                // Should use int.TryParse() here, I know :)
                age = int.Parse(ageStr);
            }
            catch (Exception ex)
            {
                // An InnerException which originates to int.Parse
                throw new InvalidInputException("Please supply a numeric value for 'age'", ex);
            }
     
            if (age < 0 || age > 150)
            {
                // No InnerException because the exception originates to our code
                throw new InvalidInputException("Please provide a reasonable value for 'age'");
            }
        }
    }
