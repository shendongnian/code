    public EmployeeVm(Employee employee)
    {
        this.InjectFrom<Employee>(employee);
        
        stringBuilder = new StringBuilder();
        stringBuilder.Append("<b>");
        stringBuilder.Append(LastName.ToUpper());
         stringBuilder.Append("</b>");
         if (!string.IsNullOrEmpty(MiddleName))
         {
               stringBuilder.Append(", ");
               stringBuilder.Append(MiddleName);
         }
          stringBuilder.Append(", ");
         stringBuilder.Append(FirstName);
         this.FullName = stringBuilder.ToString();
    }
