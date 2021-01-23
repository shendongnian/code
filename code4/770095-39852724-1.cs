    public static class Extention
        {
            public static void Bind(this Control owner, Control dataSource)
            {
                List<EventInfo> fields = dataSource.GetType().GetEvents().ToList();
                int index = fields.FindIndex(item => item.Name == "TextChanged");
                if (index >= 0)
                {
                    Control sender = dataSource as Control;
                    owner.Text = dataSource.Text;
                    dataSource.TextChanged += delegate (Object o, EventArgs e) { owner.Text = sender.Text; };
                }
            }
    
            public static void Bind(this Control owner, Control dataSource, Func<string,string> onChange)
            {
                List<EventInfo> fields = dataSource.GetType().GetEvents().ToList();
                int index = fields.FindIndex(item => item.Name == "TextChanged");
                if (index >= 0)
                {
                    Control sender = dataSource as Control;
                    owner.Text = onChange(sender.Text);
                    dataSource.TextChanged += delegate (Object o, EventArgs e) { owner.Text = onChange(sender.Text); };
                }
            }
    
            public static void Bind(this Control owner, Control dataSource, Action<string> onChange)
            {
                List<EventInfo> fields = dataSource.GetType().GetEvents().ToList();
                int index = fields.FindIndex(item => item.Name == "TextChanged");
                if (index >= 0)
                {
                    Control sender = dataSource as Control;
                    onChange(sender.Text);
                    dataSource.TextChanged += delegate (Object o, EventArgs e) { onChange(sender.Text); };
                }
            }
        }
