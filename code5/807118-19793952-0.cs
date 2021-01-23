    Panel panel; //your top-most panel; this can be as well a Form
    for (int i = 0; i < panel.Controls.Count; i++)
    {
        panel.Controls.SetChildIndex(
            panel.Controls[i], panel.Controls.Count - 1 - i
        );
    }
