    List<Control>  lstOfControls = new  List<Contol>
      public static void GetControls(Control control, bool enabled) 
     {
   
    foreach(Control child in control.Controls) {
            if(child.Name.StartsWith("Img") 
                {
                 lstOfControls.Add(control)
              }
       }
     }
