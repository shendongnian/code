    public abstract class BaseModel
    {
        public List<Icon> Icons { get; set; }
    }
    public class ModelWithIcons : BaseModel
    {
         public ModelWithIcons()
         {
            // Set up icon data
         }
    }
