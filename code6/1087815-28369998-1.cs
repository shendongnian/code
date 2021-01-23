    void OnBtnClick(...)
    {
        List<Control> ctrls = new List<Control>(Controls); 
   
        Controls.Clear();
        foreach(Control ctrl in ctrls )
             ctrl.Dispose();
        Controls.Add(new yourContrl());
    }
