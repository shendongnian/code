    int i = 0;
    foreach (TextBox t in Panel1.Controls.OfType <TextBox>())
    {
        if(answerList[i++] != t.Text.Trim())
        {
            //Change background-color of t
            t.BackColor = Color.Red;
        }
    }
