    public class FormA {
      private void btnOpenformB_Click(System.Object sender, System.EventArgs e) {
        FormB B = new FormB();
        this.Hide();
        B.Show(this);//Note we pass in the Owner here
      }
      private void btnExit_Click(System.Object sender, System.EventArgs e) {
        this.Close();
      }
    }
    public class FormB {
      private void btnReopenA_Click(System.Object sender, System.EventArgs e) {
        if(Owner!=null) Owner.Show();
        this.Close();
      }
    }
