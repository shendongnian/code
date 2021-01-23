        static LAudit()
        {
            var keys = typeof (LAudit).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(x => x.Name).ToList();
            string[] values =
            {
                "Prop1", "Prop2", "Prop3", //...
            };
            Properties = new KeyValuePair<string, string>[keys.Count];
            for (int i = 0; i < Properties.Length; i++)
            {
                Properties[i] = new KeyValuePair<string, string>(keys[i], values[i]);
            }
        }
        public static readonly KeyValuePair<string, string>[] Properties;
