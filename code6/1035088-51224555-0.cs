    [ConfigurationCollection(typeof(SchedulerTaskItem), AddItemName = "Task")]
    public class SchedulerTaskCollection: ConfigurationElementCollection
    {
        private static readonly ObjectIDGenerator idGenerator = new ObjectIDGenerator();
        protected override ConfigurationElement CreateNewElement()
        {
            return new SchedulerTaskItem();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            bool firstTime;
            return idGenerator.GetId(element, out firstTime);
        }
    }
