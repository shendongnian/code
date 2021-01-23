    public partial class FormB : Form
    {
      private Form _frm;
      public FormB(Form frm)
      {
         _frm = frm;
         InitializeComponent();
      }
      private void btnReopenA_Click(System.Object sender, System.EventArgs e) {
           if(_frm!=null) _frm.Show();
           this.Close();
      }
    }
