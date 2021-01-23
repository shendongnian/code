    char letter = 'A';
    for (int i = 0; i < SomeCollection.Count; i++)
    {
        var answer = SomeCollection[i]
        System.Web.UI.WebControls.ListItem listItem = new System.Web.UI.WebControls.ListItem();
        listItem.Value = answer.ID.ToString();
        listItem.Text = letter + "." + answer.AnswerText;
        listControl.Items.Add(listItem);
        letter++;
    }
