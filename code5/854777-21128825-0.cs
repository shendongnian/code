            var actions = new Dictionary<string, Func<MenuItem, RoutedEventHandler>>()
            {
                { "New", mi => (s, e) => { MessageBox.Show("New File Created."); }},
                { "Open", mi => (s, e) => { MessageBox.Show("File Opened."); }},
                { "Save", mi => (s, e) => { MessageBox.Show("File Saved."); }},
            };
            foreach (MenuItem mi in FileMenu.Items)
            {
                if (actions.ContainsKey(mi.Name))
                {
                    mi.Click += actions[mi.Name](mi);
                }
            }
