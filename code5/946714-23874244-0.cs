    abstract class WithBehaviors {
        private readonly List<Behavior> _behaviors;
        protected WithBehaviors() {
            _behaviors = new List<Behavior>();
        }
        protected void RegisterBehaviour(string name, Action<object> action) {
            _behaviors.Add(new Behavior(name, action));
        }
        public void Invoke(string behaviourName) {
            ActOn(behaviourName, b => {
                if (b.IsEnabled) {
                    b.Action(this);
                }
            });
        }
        public void Inhibit(string behaviourName) {
            ActOn(behaviourName, b => b.IsEnabled = false);
        }
        public void Allow(string behaviourName) {
            ActOn(behaviourName, b => b.IsEnabled = true);
        }
        private void ActOn(string name, Action<Behavior> action) {
            var behavior = _behaviors.FirstOrDefault(b => name.Equals(b.Name, StringComparison.CurrentCultureIgnoreCase));
            if (behavior != null) {
                action(behavior);
            }
        }
        private class Behavior {
            public Behavior(string name, Action<object> action) {
                Name = name;
                Action = action;
                IsEnabled = true;
            }
            public string Name { get; private set; }
            public Action<object> Action { get; private set; }
            public bool IsEnabled { get; set; }
        }
    } 
