    private void processButtons(object sender, EventArgs e)
    {
        //Get the clicked button
        Button clickedButton = (Button)sender;
        string correspondingPictureBoxName = clickedButton.Tag.ToString();
        //Get the corresponding PictureBox
        PictureBox correspondingPictureBox = (PictureBox)Controls.Find(correspondingPictureBoxName, true).First<Control>();
        //Hide the PictureBox
        correspondingPictureBox.Visible = false;
    }
