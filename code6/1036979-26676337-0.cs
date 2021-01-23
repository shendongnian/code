    // This is an example. 
    // It would not work as expected because one couldn't just apply HttpServerUtility.UrlTokenDecode(...) to a arbitrary string.
    // Also it does not deal with exceptions handling. Use it only as a stub.
        public class MyModelBinder : DefaultModelBinder {
        		public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
        			HttpRequestBase request = controllerContext.HttpContext.Request;
        			string input = request.QueryString[bindingContext.ModelName];
        			var bytes = HttpServerUtility.UrlTokenDecode(input);
        			return new Guid();
        		}
        	}
