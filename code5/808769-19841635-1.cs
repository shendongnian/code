    if (splitContainer.Panel2.Controls.Count > 0)
    {
        splitContainer.Panel2.Controls[0].Dispose();    // Edit
        splitContainer.Panel2.Controls.Clear();
    }
    splitContainer.Panel2.Controls.Add(new RightHandControl());
