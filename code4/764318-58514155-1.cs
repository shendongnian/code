    public static class ContextManager
    {
        public static HotelContext Current
        {
            get
            {
                var key = "Hotel_" + HttpContext.Current.GetHashCode().ToString("x")
                          + Thread.CurrentContext.ContextID.ToString();
                var context = HttpContext.Current.Items[key] as HotelContext;
                if (context == null || context.IsDisposed)
                {
                    context = new HotelContext();
                    HttpContext.Current.Items[key] = context;
                }
                return context;
            }
        }
    }
