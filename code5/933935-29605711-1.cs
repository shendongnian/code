     public void ShowStatusbarMessage(Form frmMdiChild, string message, NotifierType notificationType)
       {
           StatusStrip statusStrip=((frmMain)(frmMdiChild.MdiParent)).GetStatusBar;
           statusStrip.Text = message;
           if (notificationType == NotifierType.SuccessInfo)
           {
               statusStrip.ForeColor = System.Drawing.Color.Green;
           }
           else if (notificationType == NotifierType.Warning)
           {
               statusStrip.ForeColor = System.Drawing.Color.Orange;
           }
           else
           {
               statusStrip.ForeColor = System.Drawing.Color.Red;
    
           }
    
       }
