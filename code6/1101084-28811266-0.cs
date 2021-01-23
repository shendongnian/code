    private void button_Click(object sender, EventArgs e){
      while (panel.Controls.Count > 0) {
        panel.Controls[0].Dispose();
      }
      form3 myForm = new form3();
      myForm.FormBorderStyle = FormBorderStyle.None;
      myForm.TopLevel = false;
      myForm.AutoScroll = true;
      panel.Controls.Add(myForm);
      myForm.Show();
      // this.Close();
    }
