     List<Control>  lstOfControls = new  List<Contol>
          public  void AllPictureControls(Control control, bool enabled) 
         {
       
        foreach(Control child in control.Controls) {
                if(child.Name.StartsWith("pic") 
                    {
                     lstOfControls.Add(control)
                  }
           }
         }
