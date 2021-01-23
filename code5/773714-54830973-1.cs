    public abstract class BaseEmailTemplate
    {
        // No need for even a constructor
        
        private Topic topic;
        
        public Topic
        {
            get => topic;
            set
            {
                if (topic == value)
                {
                    return;
                }
                
                topic = value;
                
                // Derived methods could also access the topic
                // as this.Topic instead of as an argument
                CreateAddresses(topic);
                CreateSubject(topic);
                CreateBody(topic);
            }
        }
        
        protected abstract void CreateAddresses(Topic topic);
        
        protected abstract void CreateSubject(Topic topic);
        
        protected abstract void CreateBody(Topic topic);
    }
