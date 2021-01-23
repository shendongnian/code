    private void btnOpenformB_Click(System.Object sender, System.EventArgs e)
    {
        FormB B = new FormB();
        B.FormClosing += b_FormClosing;
        this.Hide();
        B.Show();
    }
      void b_FormClosing(object sender, FormClosingEventArgs e)
      {
         Show();
      }
