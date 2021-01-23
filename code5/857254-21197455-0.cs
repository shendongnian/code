      StringWriter sw = new StringWriter();
        length = (int)numericUpDownPasswordlength.Value;
        totalPasswords = (int)numericUpDownPassword.Value;
        for (int pwdCount=0; pwdCount < totalPasswords; pwdCount++)
        {
            string[] minatecken = symb;
            for (; length > 0; length--)
            {
                sw.Write(minatecken[rnd.Next(0, 62)]);
            }
            richTextBoxPasswords.Text = sw + "\n";
        }
