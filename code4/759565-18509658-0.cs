    foreach (Control c in ((Control)splitContainer.Panel2).Controls)
    {
        if(c is Panel)
        {
          foreach (Control curr in c.Controls)
          {
             MessageBox.Show("Name: " + curr.Name + "  Back Color: " + curr.BackColor);
          }
        }
    }
