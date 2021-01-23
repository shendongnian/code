        public class IPNModelBinder : IModelBinder
        {
            public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
            {
                if (bindingContext.ModelType != typeof(IPNBindingModel))
                {
                   return false;
                }
            var postedRaw = actionContext.Request.Content.ReadAsStringAsync().Result;
            
            Dictionary postedData = ParsePaypalIPN(postedRaw);
            IPNBindingModel ipn = new IPNBindingModel
            {
                PaymentStatus = postedData["payment_status"],
                RawRequest = postedRaw,
                CustomField = postedData["custom"]
            };
            bindingContext.Model = ipn;
            return true;
        }
        private Dictionary ParsePaypalIPN(string postedRaw)
        {
            var result = new Dictionary();
            var keyValuePairs = postedRaw.Split('&');
            foreach (var kvp in keyValuePairs)
            {
                var keyvalue = kvp.Split('=');
                var key = keyvalue[0];
                var value = keyvalue[1];
                result.Add(key, value);
            }
            return result;
        }
        }
         }
