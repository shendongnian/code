    if (cbxInbox.CheckedItems.Count > 1)
    {
        for (int i = 1; i <= cbxInbox.CheckedItems.Count; i++)
        {
            client.DeleteMessage(i + 1);
        }
    }
