    public void SetCellText(DataGridView control, int x, int y, string text)
    {
        if (this.InvokeRequired)
        {
            this.Invoke(() => SetCellText(control, x, y, text));
        }
        else
        {
            control[x, y] = text;
        }
    }
