    public class ExtendedModelBinder : DefaultModelBinder
        {
            string GetErrorMessageForType(Type type)
            {
                if (type == typeof(int))
                    return "You must enter an integer numeric value";
                if (type == typeof(double))
                    return "You must enter a numeric value";
                return "The entered value is incorrect";
            }
    
            public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
            {
                object res = base.BindModel(controllerContext, bindingContext);
    
                foreach (var entry in bindingContext.ModelState)
                {
                    if (entry.Value.Errors != null)
                    {
                        var itemsToReplace = new List<ModelError>();
                        foreach (var err in entry.Value.Errors)
                        {
                            if (string.IsNullOrEmpty(err.ErrorMessage) && err.Exception != null)
                            {
                                var ex = err.Exception;
                                while (!(ex is FormatException) && ex != null)
                                    ex = ex.InnerException;
                                if (ex != null)
                                {
                                    itemsToReplace.Add(err);
                                }
                            }
                        }
                        foreach (var err in itemsToReplace)
    	                {
                            var ex = err.Exception;
                            entry.Value.Errors.Remove(err);
    
                            entry.Value.Errors.Add(GetErrorMessageForType(bindingContext.ModelType));
    	                }
                    }
                    
                }
    
                return res;
            }
    
        }
