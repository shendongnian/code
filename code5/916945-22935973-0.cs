    // Loop each control
    foreach (Control control in this.Controls)
    {
       if (control is DataGridView) { ((DataGridView)control).BackgroundColor = Color.Red; }
       // else if (control is ...) { ... }
       // Everything else is colored by using property "BackColor"
       else { control.BackColor = Color.Red; }
    }
