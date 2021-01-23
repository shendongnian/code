    private void list_answers_SelectedIndexChanged(object sender, EventArgs e)
            {
                for (int i = 0; i < tasks.Count; i++)
                {
                    if (list_answers.Items[i].Selected == true) // find selected item
    
                    {
                        if (list_answers.Items[i].Text == "Question №" + (i + 1)) // check it's content
                        this.ShowOnePanel(i);
                        iter = i;
                        break;
                    }
                }
        }
