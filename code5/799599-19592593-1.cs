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
    public class MyObject
    {
        public MyObject()
        {
            ObjectController.Add(this);
        }
        public void Delete()
        {
            ObjectController.Remove(this);
        }
    }
