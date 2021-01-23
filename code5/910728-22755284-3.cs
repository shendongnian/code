    UserControl m = sender as UserControl;
    Style s = m.Resources["test"] as Style; 
    m.testControl = new ContentControl(); // Remove this line
    m.testControl.Style = s;              // and 'm', or write like this: this.testControl.Style = s;
    m.testControl.ApplyTemplate();
