    foreach (TextBox t in Panel1.Controls.OfType <TextBox>())
    {
        string tmp = t.Text.Trim();
        choiceList.Add(tmp);
        if(answerList[choiceList.Count-1] != tmp)
        {
            //Change background-color of t
            t.BackColor = Color.Red;
        }
    }
