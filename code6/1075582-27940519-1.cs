    [AttributeUsage(AttributeTargets.Assembly)]
    public class AppModelAttribute : Attribute {
        public ModelType Model {get;private set} // This one can be an enum type with values Web, Console
        
        public AppModel(ModelType type)
        {
            this.Model = type;
        }
    }
