     // POCO to store Window1 info
     public class Window1Values
     {
        public string TextBoxValue1 { get; set; }
        public bool CheckBoxValue1 { get; set; }
     }
    
     // Update Window 3 Ctor to look like the following, simply just add a parameter to the existing Ctor
     //
     public Window3(Window1Values window1Values)
     {
     	// ...
     }
    
     // When Window 3 is going to open, do the following
     //
     var w3 = new Window3(new Window1Values
     {
     	TextBoxValue1 = myTextBox.Text;
     	CheckBoxValue1 = myCheckBox.IsChecked;	
     });
     w3.ShowDialog();
