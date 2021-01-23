    string value = "";
    if (data.TryGetValue(s1.MessageBody, out value))
    {
        txtMessage.Text = txtMessage.Text.Replace(s1.MessageBody, value);
    }
