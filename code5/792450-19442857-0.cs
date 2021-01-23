     var desktop = AutomationElement.RootElement;
     foreach (AutomationElement element in desktop.FindAll(TreeScope.Children, Condition.TrueCondition))
     {
         if (element.Current.ClassName != "CabinetWClass")
         {
              continue;
         }
         Console.WriteLine("{0}, {1}",element.Current.Name, element.Current.ClassName);
     }
