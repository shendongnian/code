    public class DataProvider2
    {
        private readonly List<ScriptBase> _scripts = new List<ScriptBase>();
        public void Subscribe(ScriptBase script)
        {
            _scripts.Add(script);
        }
        public void Unsubscribe(ScriptBase script)
        {
            _scripts.Remove(script);
        }
        public void DoSomethingThatTriggersPriorEvents(int someValue)
        {
            Prior prior = someValue % 2 == 0 ? Prior.Moderate : Prior.Terminal;
            foreach (var script in _scripts)
            {
                if (script.Prior == prior)
                {
                    script.Apply();
                }
            }
        }
    }
    
