    var controls = viewer1.Controls.Cast<Control>();
    foreach (Control control in controls)
    
        {
          // Check fot TableOfContents Control
          if (control.Name == "TableOfContents")
         {
                                // Getting the TabControl.
                                var contColletion = control.Controls;
                                Control tabCollection = contColletion[0];
                                TabControl tabControl = (TabControl)tabCollection;
                                tabControl.Appearance = TabAppearance.Normal;
                                // Remove the Thumbnail Tab from Control.
                                tabControl.TabPages.RemoveAt(1);
                            }
                        }
