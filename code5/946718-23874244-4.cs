    public abstract class WithBehaviors : IStateful {
        private readonly List<IState> _states;
        private readonly List<Behavior> _behaviors;
        private readonly IEnvironment _environment;
        protected WithBehaviors(IEnvironment environment) {
            _environment = environment;
            _behaviors = new List<Behavior>();
            _states = new List<IState>();
        }
        #region IStateful
		
        public void SetState(string name) {
            SetState(name , o=> true);
        }
        
        public void SetState(string name, Func<object, bool> test) {
            if (_states.Any(s => Match(s, name))) {
            throw new ArgumentException();
            }
            _states.Add(new State(name, test));
        }
        public void ClearState(string name) {
            _states.RemoveAll(s => Match(s, name));
        }
        public bool IsInState(string name) {
            var theState = _states.FirstOrDefault(s => Match(s, name));
            return theState != null && theState.Is(this);
        }
        private static bool Match(IState state, string name) {
            return state.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase);
        }
        #endregion
        public void RegisterBehaviour(string name, Action<object> defaultAction) {
            _behaviors.Add(new Behavior(name, defaultAction));
        }
        public void RegisterBehaviorModifier(
            string name, 
            Func<IEnvironment, IStateful, bool> check,
            Action<object> replacementAction = null
        ) {
            ActOn(name, 
	            b => b.BehaviorActions.Add(new BehaviorAction(check, 
                                                              replacementAction ?? (o =>{}))));
        }
        public void Invoke(string behaviourName) {
            ActOn(behaviourName, behavior => {
                var replacement = behavior.BehaviorActions.FirstOrDefault(b => b.Check(_environment, this));
                if (replacement == null) {
	                behavior.DefaultAction(this);
                } else {
	                replacement.Action(this);
                }
            });
        }
        private void ActOn(string name, Action<Behavior> action) {
            var behavior = _behaviors.FirstOrDefault(b => name.Equals(b.Name, StringComparison.CurrentCultureIgnoreCase));
            if (behavior != null) {
                action(behavior);
            }
        }
        private class Behavior {
            public Behavior(string name, Action<object> defaultAction) {
                Name = name;
                DefaultAction = defaultAction;
                BehaviorActions = new	List<BehaviorAction>();
            }
            public string Name { get; private set; }
            public Action<object> DefaultAction { get; private set; }
            public List<BehaviorAction> BehaviorActions { get; private set; }
        }
        private class BehaviorAction {
            public BehaviorAction(Func<IEnvironment, IStateful, bool> check, Action<object> action) {
                Check = check;
                Action = action;
            }
            public Func<IEnvironment, IStateful, bool> Check { get; private set; }
            public Action<object> Action { get; private set; }
        }
		
    }
    public class WithBehaviors<T> : WithBehaviors where T : class {
        public WithBehaviors(IEnvironment environment) : base(environment) {}
        public void RegisterBehaviour(string name, Action<T> defaultAction) {
            base.RegisterBehaviour(name, obj => defaultAction((T)obj));
        }
        public void RegisterBehaviorModifier(
            string name,
            Func<IEnvironment, IStateful, bool> check,
            Action<T> replacementAction = null
        ) {
            base.RegisterBehaviorModifier(name, 
                                          check,
                                          (replacementAction != null)
                                              ? (Action<object>)(o => replacementAction((T)o))
                                              : null);
        }
    }
    public  class Rabbit : WithBehaviors<Rabbit> {
        public Rabbit(IEnvironment environment) : base(environment){}
        public int XVal { get; set; }
    }
    public class State : IState {
        private readonly Func<object, bool> _test;
        public State(string name, Func<object, bool> test = null) {
            Name = name;
            _test = test;
        }
        public string Name { get; private set; }
		
        public bool Is(object target) {
            return _test(target);
        }
    }
