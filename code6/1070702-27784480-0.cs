    public class CustomerSelectorResultModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var data = base.BindModel(controllerContext, bindingContext);
    
            var model = data as CustomerSelectorResult;
            //check if CustomerSelectorResult's all properties are null except DisplayId.
            if(model != null &&
               model.Name == null &&
               model.RoleId == default(int) &&
               model.RoleName == null &&
               model.Address == null)
            {
                return null;
            }
    
            return data;
        }
    }
