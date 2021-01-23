    public static void MethodName (IEnumerable<Control> controls)
    {
        foreach (var ctrl in controls)
        {
            switch (ctrl.TYPE)
            {
               case "StaticText":
                  CompareControls.StaticText lbl = new CompareControls.StaticText();        
                  page1.tabPage1.Controls.Add(lbl);        
                  break;
        
               case "CheckBox":        
                  break;        
              }
         }
    }
