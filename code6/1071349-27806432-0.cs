    using System;
    using System.Diagnostics;
    using System.Windows.Automation;
    static void Main(string[] args)
    {
        var windows = AutomationElement.RootElement.FindAll(TreeScope.Descendants, 
            new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));
        foreach(AutomationElement window in windows)
        {
            var props = window.Current;
            var proc = Process.GetProcessById(props.ProcessId);
            Console.WriteLine("{0} {1} {2}", props.ProcessId, proc.ProcessName, props.Name);
        }
    }
