    [ContentProperty ("Default")]
    public class OnIdiomExtension : IMarkupExtension
    {
        public object Default { get; set; }
    
        public object Phone { get; set; } 
        
        public object ProvideValue (IServiceProvider serviceProvider)
        {
            object val = Default;
            
            switch (Device.Idiom) {
            case TargetIdiom.Phone:
                val = Phone ?? Default;
                break;
            }
    
            return val;
        }
    }
