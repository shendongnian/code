    //first, you have to set the lastChecked = radioButton1 (or another of your radioButtons)
    RadioButton lastChecked;
    //Click event handler used for all the radioButtons
    private void RadiosClick(object sender, EventArgs e)
    {
       RadioButton radio = sender as RadioButton;
       if (radio != lastChecked){
          radio.Checked = true;
          lastChecked.Checked = false;
          lastChecked = radio;
       }
       //else radio.Checked = !radio.Checked;     
    }
