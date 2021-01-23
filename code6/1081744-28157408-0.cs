    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (TextBox2.Text != TextBox3.Text)
            {
                Label1.Text = "Not the same values";
                args.IsValid = false;
            }
          }
