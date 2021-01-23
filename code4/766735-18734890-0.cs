    public static void RegisterTaskServiceType(System.Type t)
        {
            Type iface = t.GetInterface("itaskservice",true);
    
            if (iface == null)
                throw new ArgumentException("Type-Argument needs to implement ITaskService.");
            else if (taskServiceTypes.Contains(t))
                throw new InvalidOperationException(string.Format("Type {0} is already registered.",t.FullName));
            else
                taskServiceTypes.Add(t);
        }
