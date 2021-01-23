    // This is an example. 
    // Note the returning of null which is undesired.
    // Also it does not deal with exceptions handling. Use it only as a stub.
        public class ExtendedModelBinder : DefaultModelBinder {
        		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
        			if (!(bindingContext.ModelType == typeof(Guid)))
        				return base.BindModel(controllerContext, bindingContext);
        			if (!bindingContext.ValueProvider.ContainsPrefix(bindingContext.ModelName))
        				return null;
        			string input = bindingContext.ValueProvider.GetValue(bindingContext.ModelName).AttemptedValue;
        			if (string.IsNullOrEmpty(input))
        				return null;
        			Guid g;
        			if (Guid.TryParse(input, out g))
        				return g;
                    var bytes = HttpServerUtility.UrlTokenDecode(s);
        			var result = new Guid(bytes);
        			return result;
        		}
        	}
