    public void addToStackPanel(string argBuiltAlarm)
    {
       //creating a stackpanel with orientation horizontal
       StackPanel stackPanel=new StackPanel
            {
               Orientation =System.Windows.Controls.Orientation.Horizontal
            };
       TextBox textBox=new TextBox{ Text =  "your text"};
       CheckBox checkQueries = new CheckBox() { Content = argBuiltAlarm };
       stackPanel.Children.Add(checkQueries);
       stackPanel.Children.Add(textBox);
       //adding the stackpanel containing both checkbox & textbox to the stackPanel1
       stackPanel1.Children.Add(stackPanel);
            
       //remaining codes here
     }
