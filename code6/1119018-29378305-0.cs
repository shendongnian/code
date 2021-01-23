    string target;
    text = "";
    password = richTextBox2.Text;
    for (int i = 0; i <= password.Length - 1; i += 2)
    {
        target = Convert.ToString(password[i]) + Convert.ToString(password[i + 1]);
        if (target == ",,")
        {
            text += "a";
        }
    }
    richTextBox3.Text = text;
