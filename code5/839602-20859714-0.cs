    public override void VerifyRenderingInServerForm(Control control)
         {
             Macro grid = control as Macro ;
             if (grid != null && grid.ID == "Macro1")
                 return;
             else
                 base.VerifyRenderingInServerForm(control);
        
         }
