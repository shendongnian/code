    public class ValidDepartment : Department, IDataErrorInfo
    {
        #region IDataErrorInfo Members
        public string Error
        {
            get { return null; }
        }
        public string this[string name]
        {
            get 
            {
                if (name == "DepartmentCode")
                {
                    if (string.IsNullOrEmpty(DepartmentCode)
                        return "DepartmentCode can not be empty";
                }
                
                if (name == "DepartmentFullName")
                {
                    if (string.IsNullOrEmpty(DepartmentFullName)
                        return "DepartmentFullName can not be empty";
                }
                return null;
            }
        }
        #endregion
    }
