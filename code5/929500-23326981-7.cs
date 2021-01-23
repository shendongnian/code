    private static void FillWith(Panel container, IEnumerable<string> values)
    {
        Queue<string> queue = new Queue<string>(values);
        foreach (var textbox in container.Controls.OfType<TextBox>())
        {
            // Not enough values to fill all textboxes
            if (queue.Count == 0)
                return;
            textbox.Text = queue.Dequeue();
        }
    }
