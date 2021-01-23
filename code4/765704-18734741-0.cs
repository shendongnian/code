        private  AutomationElement GetAutomationElementFromPoint(Point location)
        {
         
            
            AutomationElement automationElement =null;
          
            Thread thread = new Thread(() =>
            {
                automationElement = AutomationElement.FromPoint(location);
            });
           
            thread.Start();
            thread.Join();
            return automationElement;
        }
         private void mouseHook_MouseClick(object sender, MouseEventArgs e)
        {
            AutomationElement element = GetAutomationElementFromPoint(new System.Windows.Point(e.X, e.Y));
       
            //Thread.Sleep(900);
            if (element != null)
            {
              
               textBox1.Text =  "Name: " + element.Current.Name + " ID: " + element.Current.AutomationId + " Type: " + element.Current.LocalizedControlType;
            }
            else
               textBox1.Text = "Not found";
        }
