    public class GroepModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
            string id = request.Form.Get("Groep.Id");
            string naam = request.Form.Get("Groep.Naam");
            string plcode = request.Form.Get("Groep.PLCode");
            return new GroupEditViewModel
            {
                Groep = new Business.Models.Groep
                {
                    Id = int.Parse(id),
                    Naam = naam,
                    PLCode = plcode
                }
            };
        }
    }
