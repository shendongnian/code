    public class MyModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            try
            {                
                var request = controllerContext.HttpContext.Request;
                return new MyModel
                {
                    MyEmpls = request[] ?? new Employees[0],
                    Id = request["Id"] ?? "",
                    OrgName = request["OrgName"] ?? ""
                };
            }
            catch 
            {
                //do required exception handling
            }
        }
    }
