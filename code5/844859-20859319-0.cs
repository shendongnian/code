    public void objChecked(Control x, bool enabled)
        {
            if(x as RadioButton == null && x as CheckBox == null)
              throw new Exception("Not supported");
    
    
            dynamic runtimeObject = (dynamic)x;
            if (x.InvokeRequired)
            {
                BeginInvoke(new MyDelegate(delegate()
                {
                    runtimeObject.Checked = enabled;
                }));
            }
            else
            {
                runtimeObject.Checked = enabled;
            }
        }
