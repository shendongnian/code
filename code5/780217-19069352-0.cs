    public class ObjectFactory
    {
        public static IObjectController CreateObjectController(ObjectSettings settings)
        {
            IObjectController result = (settings.PINK ? new PinkObject() : (IObjectController) new BlueObject());
            result.Initialise(settings);
            return result;
        }
    }
