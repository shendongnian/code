    public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            object model = bindingContext.Model;
            Employee employee = (Employee)model;
            if (employee == null)
            {
                employee = new Employee();
            }
            string departnementName = "DepartmentName";
            var departnementNameValue = bindingContext.ValueProvider.GetValue(departnementName);
            try
            {
                if (departnementName == "IT")
                {
                    employee.StatusID = 1;
                }
            }
            catch (Exception ex)
            {
                bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex.Message);
                bindingContext.ModelState.SetModelValue(departnementName, departnementNameValue);
            }
            return employee;
        }
