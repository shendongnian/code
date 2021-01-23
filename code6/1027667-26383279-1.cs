    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Automation;
    namespace tests
    {
        class Program
        {
         static void Main(string[] args)
         {
            foreach (Process process in Process.GetProcessesByName("chrome"))
            {
                string url = GetChromeUrl(process);
                if (url == null)
                    continue;
                Console.WriteLine("CH Url for '" + process.MainWindowTitle + "' is " + url);
            }
        }
        public static string GetChromeUrl(Process process)
        {
            if (process == null)
                throw new ArgumentNullException("process");
            if (process.MainWindowHandle == IntPtr.Zero)
                return null;
            AutomationElement element = AutomationElement.FromHandle(process.MainWindowHandle);
            if (element == null)
                return null;
            AutomationElementCollection edits5 = element.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit));
            AutomationElement edit = edits5[0];
            string vp = ((ValuePattern)edit.GetCurrentPattern(ValuePattern.Pattern)).Current.Value as string;
            Console.WriteLine(vp);
            return vp;
        }
    }
}
