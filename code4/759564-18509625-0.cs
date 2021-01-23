    public IEnumerable<Control> GetControls(Control c){            
      return new []{c}.Concat(c.Controls.OfType<Control>()
                                        .SelectMany(x => GetControls(x)));
    }    
    foreach(Control c in GetControls(splitContainer.Panel2).Where(x=>x is Label || x is Button))
       MessageBox.Show("Name: " + c.Name + "  Back Color: " + c.BackColor);
             
                                               
