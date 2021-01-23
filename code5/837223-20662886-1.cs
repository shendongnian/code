    public static class InterfaceExtensions
    {
        public static T TryAlignToInterface<T>(this AsmHelper helper, object obj) where T : class
        {
            try
            {
                return helper.AlignToInterface<T>(obj);
            }
            catch
            {
                return null;
            }
        }
    }
