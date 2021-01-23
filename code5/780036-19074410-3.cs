     public class TimeModelBinder:DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var model = (TestModel)base.BindModel(controllerContext, bindingContext);
            var Hour = controllerContext.HttpContext.Request["TimeWorked.Hours"];
            var minutes = controllerContext.HttpContext.Request["TimeWorked.Minutes"];
            var time = new TimeSpan(int.Parse(Hour), int.Parse(minutes), 0);
            model.TimeWorked = time;
            return model;
        }
    }
