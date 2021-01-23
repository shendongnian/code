            var strategy =   activator.CreateInstance(Type.GetType("BackTester."+boxStrategy.Text));
            foreach (FieldInfo prop in strategy.GetType().GetFields(BindingFlags.Public
                | BindingFlags.Instance))
            {
                listBox1.Items.Add(prop.ToString() + " " + prop.GetValue(strategy));
            }
