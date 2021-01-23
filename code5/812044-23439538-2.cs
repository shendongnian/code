    namespace NotYourDefaultNamespace
    {
        public static class ModelExtensions
        {
            public static T Data<T>( this Object model, String key)  
            {
                return (T)model.GetType().GetProperty(key).GetValue(model) ;
            }
        }
    } 
