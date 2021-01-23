    private void CreateMemo(object sender, EventArgs args)
    {            
         Form2.Memos.Add(
                new memo(priorityNumber.Text, memoTitle.Text, memoDescription.Text));
    }
