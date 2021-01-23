    var index = 0;
    Dictionary<int, PictureBox> pictureBoxes = u.Controls
                                                .OfType<PictureBox>
                                                .ToDictionary(key => index++)
    
    for(var i = 0; i < index; i++)
    {
      pictureBoxes[i].ImageLocation = artists[i].artistPic;
    }
