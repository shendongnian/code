        public static T Resolve<T>()
        {
            try
            {
                return windsorContainer.Resolve<T>();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
