    public class MyViewModelBinder: IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, 
                                ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;
    
            List<ObjectModel> list = new List<ObjectModel>(); 
            var ids= form.GetValues("Add"); 
            //in your case your ids would be the names of your items
            foreach (var id in ids)
            {
               list.Add(new ObjectModel(){ Name = id, Checked= true});  
            }
    
            return new MyViewModel
                       {
                           MyList = list
                       };
        }
    } 
