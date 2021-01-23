    public void AddRadioButton(string fullName, string imagePath, int getID)
    {
        RadioButton radio = new RadioButton { Text = fullName, Parent = PresPanel };
        //.....
        radio.Tag = getID;
        radio.CheckedChanged += radio_CheckedChanged;
    }
    //then in the CheckedChanged event handler
    private void radio_CheckedChanged(object sender, EventArgs e){
      RadioButton radio = sender as RadioButton;
      int getID = (int) (radio.Tag ?? -1);//suppose -1 is an invalid ID which is used to indicate that there is not associated ID
      //other code....
    }
