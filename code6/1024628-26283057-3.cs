    private void btn_Click(object sender, EventArgs e)
    {
       if(ff)
          txtNum2.Text += (sender as Button).Text;       
       else       
          txtNum1.Text += (sender as Button).Text;       
    }
