    private void NewNoiseButton_Click( object sender, EventArgs e )
    {
      CheckBox checkBox = new CheckBox();
      buttonList.Add( checkBox );
      int buttonNumber = buttonList.Count - 1;
      checkBox.CheckedChanged += new EventHandler( CheckBoxCheckedChanged );
      buttonList[ buttonNumber ].Location = new Point( 2, buttonList.Count * 30 - 30 );
      allNoisePanel.Controls.Add( buttonList[ buttonNumber ] );
    }
    void CheckBoxCheckedChanged( object sender, EventArgs e )
    {
      CheckBox checkBox = sender as CheckBox;
      if (checkBox!=null)
      {
        if (checkBox.Checked)
        {
          // do something
        }
        else
        {
          // do something else
        }
      }
    }
