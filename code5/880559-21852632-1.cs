    private void textBox1_TextChanged(object sender, EventArgs e)
    {
       if( _listContact.Contain(sender.Text))
       {
          textbox2.Text = _listContact[sender.Text].Number;
          textbox3.Text = _listContact[sender.Text].Mail;
       }
    }
