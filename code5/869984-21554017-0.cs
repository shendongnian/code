    public void performSwitch(int pictureBoxWaarde)
    {
        // Get current special picture box
        PictureBox currentSpecial = this.Controls.Find(m_specialPictureBoxName, true) as PictureBox;
 
        // Get new special picture box
        m_currentPictureBoxName = String.Format("pictureBox{0}", pictureBoxWaarde);
        PictureBox clicked = this.Control.Find(m_currentPictureBoxName, true) as PictureBox;
        // Swap images
        Image temp = currentSpecial.Image;
        currentSpecial.Image = clicked.Image;
        clicked.Image = temp;
    } 
