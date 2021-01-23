     public void MailEmptyFieldPopulate(Control ctrl, string text = null)
    {
       if(ctrl==null) return;  
       ctrl.Text = string.IsNullOrEmpty(text)?"<Empty Field>":text;
       
    }
