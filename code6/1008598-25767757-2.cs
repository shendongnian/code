    static class CleverSwitch
    {
        public class CaseInfo
        {
            public Func<bool> Condition { get; set; }
            public Action Action { get; set; }
        }
        public static void Do(object source, params CaseInfo[] cases)
        {
            var type = source.GetType();
            foreach (var entry in cases)
            {
                if (entry.Condition())
                {
                    entry.Action();
                    break;
                }
            }
        }
        public static CaseInfo IsType<T>(Type T2, Action action)
        {
            return new CaseInfo() { Condition = () => T2 == typeof(T), Action = action };
        }
        public static CaseInfo If(Func<bool> condition, Action action)
        {
            return new CaseInfo() { Condition = condition, Action = action };
        }
        public static CaseInfo Default(Action action)
        {
            return new CaseInfo() { Condition = () => true, Action = action };
        }
    }
