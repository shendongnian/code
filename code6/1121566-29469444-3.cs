    var dbValues = new Queue<int>(Enumerable.Range(1, 5));
    PerformOperationOnVisualTreeControl<TextBox>(this.TimeTableSubWrapPanel, (control) =>
    {
        control.Clear();
        if (dbValues.Count > 0)
        {
            control.Text = dbValues.Dequeue().ToString();
        }
    });
