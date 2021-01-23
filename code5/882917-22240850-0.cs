    using System.Windows.Automation;
    using System.Diagnostics;
    using System.Threading;
    
    class Program
    {
     [System.STAThread]
     public static void Main(string[] args)
     {     
      Automation.AddAutomationEventHandler(
       WindowPattern.WindowOpenedEvent,
       AutomationElement.RootElement,
       TreeScope.Children,
       (sender, e) =>
       {
        var element = sender as AutomationElement;
    
        Console.WriteLine("new window opened");
       });
    
      Console.ReadLine();
    
      Automation.RemoveAllEventHandlers();
     }
    }
