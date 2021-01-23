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
            ObjectController.ExistingObjects.Add(this);
        }
        public void Delete()
        {
            ObjectController.ExistingObjects.Remove(this);
        }
    }
