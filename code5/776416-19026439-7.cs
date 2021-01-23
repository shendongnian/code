    public class DepartmentValidator
    {
        private class PropertyNames
        {
            public const string DepartmentFullName = "DepartmentFullName";
            public const string DepartmentCode = "DepartmentCode";
        }
    
        public IList<ValidationError> Validate(Department department)
        {
            var errors = new List<ValidationError>();
    
            if(string.IsNullOrWhiteSpace(department.DepartmentCode))
            {
                errors.Add(new ValidationError { ErrorDescription = "Department code must be specified.", Property = PropertyNames.DepartmentCode});
            }
    
            if(string.IsNullOrWhiteSpace(department.DepartmentFullName))
            {
                errors.Add(new ValidationError { ErrorDescription = "Department name must be specified.", Property = PropertyNames.DepartmentFullName});
            }
    
            if (errors.Count > 0)
            {
                return errors;
            }
    
            return null;
        }
    }
