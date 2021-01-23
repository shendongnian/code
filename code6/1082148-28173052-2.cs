        List<PluginBase> plugins = new List<PluginBase>();
        private void Form1_Load(object sender, EventArgs e) //Hook in the event too
        {
            DirectoryInfo dir = (new FileInfo(Assembly.GetExecutingAssembly().Location)).Directory;
            foreach (var item in dir.GetFiles())
            {
                if (item.Name.Contains("Plugin") && item.Name.EndsWith(".dll"))
                {
                    Assembly ass = Assembly.LoadFile(item.FullName);
                    foreach (Type type in ass.GetTypes().Where(t => t.BaseType.Name == "PluginBase"))
                    {
                        PluginBase pibase = (PluginBase)Activator.CreateInstance(type,false);
                        plugins.Add(pibase);
                    }
                    
                }
            }
            foreach (var item in plugins)
            {
                item.ShowControl += item_ShowControl;
                item.Initialize();
            }
        }
        void item_ShowControl(object sender, ControlToBeShownEventArgs e)
        {
            this.Controls.Add(e.TheControl);
        }
