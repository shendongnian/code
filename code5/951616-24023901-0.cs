    public static bool DisposeDynamicObjects(List<Control> NonDynamicControls, Control.ControlCollection ControlsToDispose)
    {
       try
       {
          for (int i = 0; i < ControlsToDispose.Count; i++)
          {
             if (ControlsToDispose[i] != null &&
                 !ControlsToDispose[i].IsDisposed &&
                 !NonDynamicControls.Contains(ControlsToDispose[i]))
             {
                ControlsToDispose[i].Dispose();
                --i;
             }
          }
          return true;
       }
       catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
    }
