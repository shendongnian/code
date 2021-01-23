    public static double[] GetUIPosition(string name)
    {
        if (FastUICheck.FastUICheckVisible(name, 0) == true)
        {
           UIControl control = new UIControl(Engine.Current.Memory, Engine.Current.ObjectManager.x984_UI.x0000_Controls.x10_Map[name].Value.Address);
           double[] point = new double[4];
           point[0] = control.x4D8_UIRect.Left;
           point[1] = control.x4D8_UIRect.Top;
           point[2] = control.x4D8_UIRect.Right;
           point[3] = control.x4D8_UIRect.Bottom;
    
           return point;  
       }
       else
       {
          return null;
       }
    }
