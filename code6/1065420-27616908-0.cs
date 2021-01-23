        foreach (Control c in this.Controls)
        {
            if (c.GetType() == typeof(Button))
            {
                c.BackColor = Color.Black;
            }
        }
