    public static void Validate<T>(this T entity)
            {
                var errors = new List<ValidationResult>();
                var result = "";
    
                try
                {
                    var context = new ValidationContext(entity, null, null);
                    Validator.TryValidateObject(entity, context, errors);
                    result = (errors.Any()) ? string.Join(",", errors.Select(s => s.ErrorMessage)) : "";
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
    
                if (!string.IsNullOrEmpty(result))
                {
                    throw new Exception(result);
                }
            }
