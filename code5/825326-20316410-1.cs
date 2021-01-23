        [System.AttributeUsage(System.AttributeTargets.Method)]
        public class ClientFunctionAttribute : System.Attribute
        {
            private static List<MethodInfo> _targets;
            public static List<MethodInfo> Targets
            {
                get
                {
                    if (_targets == null)
                    {
                        _targets = Assembly.GetExecutingAssembly().GetTypes()
                      .SelectMany(t => t.GetMethods())
                      .Where(m => m.GetCustomAttributes(typeof(ClientFunctionAttribute), false).Length > 0)
                      .ToList();
                    }
                    return _targets;
                }
            }
            public string Display;
            public string Tooltip;
            public ClientFunctionAttribute(string display, string tooltip = null)
            {
                Display = display;
                Tooltip = tooltip;
            }
        }
