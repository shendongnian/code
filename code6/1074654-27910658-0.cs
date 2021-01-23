    foreach (Control c in panel1.Controls.OfType<Button>().ToList())
    {
        panel1.Controls.Remove(c);
        c.Dispose();
    }
