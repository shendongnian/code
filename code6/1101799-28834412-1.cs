    public partial class AtmMainView : Form
    {
       AtmModel model;
       
       public AtmMainView()
       {
          InitializeComponent();
          this.model = new AtmModel();
       }
       private void Withdraw_Click(object sender, System.EventArgs e)
       {
          AtmWithdrawView form = new AtmWithdrawView(this.model);
          form.Show();
       }
    }
