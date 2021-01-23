    protected void btnRemoveTextBox_Click(object sender, EventArgs e)
    {
      foreach (Control control in PlaceHolder1.Controls)
      {
        string id = "Textbox" + counter;
        if (control.ID == id)
        {
          controlIdList.Remove(id);
          PlaceHolder1.Controls.Remove(control);
          break;
        }
      }
    }
