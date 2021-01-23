    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if(checkBox1.Checked)
      {
         using (System.IO.File.Create("myprogam.lock"));
      }
      else
      {
         System.IO.File.Delete("myprogam.lock")
      }
    }
