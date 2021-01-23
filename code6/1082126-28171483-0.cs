    private void someButton_Click(object sender, EventArgs e)
    {
      using (FormB newForm = new FormB())
      {
        if (newForm.ShowDialog(this) == DialogResult.OK)
        {
          switch (newForm.UserSelection)
          {
            case 0:
              {
                // Add one node
                break;
              }
            case 1:
              {
                // Add two nodes
                break;
              }
            case 2:
              {
                // Add x nodes, etc
                break;
              }
          }
        }
      }
    }
