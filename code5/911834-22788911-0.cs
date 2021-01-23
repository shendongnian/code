    class Program
    {
        static void Main(string[] args)
        {
            Process process = Process.GetProcessesByName("taskmgr").FirstOrDefault();
            var condition = new PropertyCondition(AutomationElement.ProcessIdProperty, process.Id);
            AutomationElement window = AutomationElement.RootElement.FindFirst(TreeScope.Children, condition);
            AutomationElementCollection descendents = window.FindAll(TreeScope.Descendants, Condition.TrueCondition);
            foreach (var descendent in descendents)
            {
                var foo = descendent as AutomationElement;
                if (!string.IsNullOrWhiteSpace(foo.Current.AcceleratorKey))
                    Console.WriteLine(foo.Current.AcceleratorKey);
                if (!string.IsNullOrWhiteSpace(foo.Current.AccessKey))
                    Console.WriteLine(foo.Current. AccessKey);
            }
            
            Console.WriteLine(descendents.Count);
            Console.ReadLine();
        }
    }
