    //Created an Interface on .aspx page:
    public interface ICommandable
    {
        void LblMaintenanceClick(object argument, EventArgs e);
        } 
    public partial class Default : Page, ICommandable
    {
     public void LblMaintenanceClick(object sender, EventArgs e)
               {
                    
                 }
    }
        // On master page: 
          public void lbtnMaintenance_OnClick(object sender, EventArgs e)
                     {
                            if (Page is ICommandable)
                        {
                             (Page as ICommandable).LblMaintenanceClick(sender, e);
                         }
                     else
                         throw new NotImplementedException("u NO WURK");
                }
