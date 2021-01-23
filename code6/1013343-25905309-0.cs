        public static IEnumerable<Monitor> Monitors
        {
            get
            {
                List<Monitor> monitors = new List<Monitor>();
                List<Type> classes = GetClasses(typeof(Monitor)).OrderBy(x => x.Name).ToList();
                foreach (Type c in classes)
                {
                    object oMonitor = Activator.CreateInstance(c);
                    Monitor mig = (Monitor)oMonitor;
                    monitors.Add(mig);
                }
                return monitors;
            }
        }
