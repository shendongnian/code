    public void button1_Click(object sender, EventArgs e)
    {
      if (textBox1.Text == "" || textBox2.Text == "")
      {
          MessageBox.Show(" Enter UserName and Password .");
          return;
      }
      else
      {
          const string f = @"users.txt";
          const string p = @"passwd.txt";
          string[] lines = System.IO.File.ReadAllLines(f);
          string[] lines1 = System.IO.File.ReadAllLines(p);
          if (Array.IndexOf(lines, textBox1.Text) != -1 && Array.IndexOf(lines1, textBox2.Text) != -1)
          {
              MessageBox.Show("correct");
              this.DialogResult = System.Windows.Forms.DialogResult.OK;
              this.Close();
          }
          else
          {
              MessageBox.Show("Not Correct");
          }
      }
    }
    private void button2_Click(object sender, EventArgs e)
    {
      this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.Close();
    }
