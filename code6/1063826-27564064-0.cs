    public class ViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = base.BindModel(controllerContext, bindingContext) as ViewModel;
    
            if (model.AssignedUserName == "-1")
                bindingContext.ModelState.AddModelError("AssignedUserName", "No assignee selected");
    
            return model;
        }
    }
