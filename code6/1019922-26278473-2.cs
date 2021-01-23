    public class Bootstrapper {
        public void Init() {
            ServiceStack.Text.JsConfig.ExcludeTypeInfo = false;
            ServiceStack.Text.JsConfig.IncludeTypeInfo = true;
            
            ServiceStack.Text.JsConfig.TypeAttr = "type";
            ServiceStack.Text.JsConfig.TypeFinder = type =>
            {
                if ("CustomTypeName".Equals(type, StringComparison.OrdinalIgnoreCase))
                {
                    return typeof(ChildA);
                }
                return typeof(BaseClass);
            }
        }
    }
