      private void label_Click(object sender, EventArgs e)
       {
           Label label1 = (Label)sender;
           if (label1.BackColor == Color.Red)
                label1.BackColor = Color.Transparent;
           else
                label1.BackColor = Color.Red;
       }
