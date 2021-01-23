    private void textBoxSource_Leave(object sender, EventArgs e)
    {
        showErrorLabel(labelSourceError, textBoxSource.Text, r => yourBusinessObject.source = r);
    }
    private void showErrorLabelString(Label l, string textboxtext, Action<string> update)
    {
        if ((string.IsNullOrEmpty(s)) || (s.Length > 50))
        {
            isError = isError && false;
            l.Text = "Please Enter Data and Should be smaller than 50 Character";
            l.Visible = true;
        }
        else
        {
            update(textboxtext);
        }
    }
