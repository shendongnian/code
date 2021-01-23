    protected void listControls(Control c) {
        if (c.HasControls()) {
            litText.Text += String.Format("{0}{1}{2}", c.GetType(), c.ID, System.Environment.NewLine);
            foreach (Control control in c.Controls) {
                litText.Text += String.Format("{0}{1}{2}", control.GetType(), control.ID, System.Environment.NewLine);
                listControls(control);
            }
        }
    }
