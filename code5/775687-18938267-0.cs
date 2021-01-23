        public class AIbundles
        {
            public Dictionary<string, IExampleBehavior> ExampleBehaviors { get; set; }
            public AIbundles()
            {
                this.ExampleBehaviors = new Dictionary<string, IExampleBehavior>();
            }
        } 
        public class agent {
            AIbundles bundles = new AIbundles();
            public void UpdateBehavior (IExampleBehavior behavior)
            {
                this.bundles.ExampleBehaviors[behavior.Name] = behavior;
            }
         }
