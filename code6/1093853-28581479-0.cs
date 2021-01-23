    public class IsImageValidator<T> : PropertyValidator
    {
        private Action<T, Bitmap> _action;
        public IsImageValidator(Action<T, Bitmap> action) : base("Not valid image data")
        {
            _action = action;
        }
        protected override bool IsValid(PropertyValidatorContext context)
        {
            var isNull = context.PropertyValue == null;
            if (isNull)
            {
                return false;
            }
            try
            {
                // we need to determine the height and width of the image
                using (var ms = new System.IO.MemoryStream((byte[])context.PropertyValue))
                {
                    using (var bitmap = new System.Drawing.Bitmap(ms))
                    {
                        // valid image, so call action
                        _action((T)context.Instance, bitmap);                        
                    }
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
