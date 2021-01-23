    public partial class edit : UserControl
    {
         public EventHandler DataUpdated; 
    }
    private void UpdateAcc_Click(object sender, EventArgs e)
    {
       // Saving Data In DB
   
       //MainForm main = Form.ActiveForm as MainForm;
       //manageACC main1 = this.Parent.Parent.Parent.Parent as manageACC;
       //main1.refreshDVG1();
       //Instead of commented code raise the event
       if(DataUpdated != null)
          DataUpdated(this, System.eventArgs.Empty);
    }
