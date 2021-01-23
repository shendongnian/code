    public static class ObjectController
    {
        private static IList<object> existingObjects;
        public static IList<object> ExistingObjects
        {
            get 
            {
                if (existingObjects == null)
                {
                    existingObjects = new List<object>();
                }
            }
        }
    }
