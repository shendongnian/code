    List<PictureBox> pictureBoxes = new List<PictureBox>();
    // fill the list
    pictureBoxes.Add(...);
    // do something to all boxes in the list
    pictureBoxes.ForEach(box => box.Visible = true);
    // ask something about the boxes in the list
    if (pictureBoxes.Any(box => box.Visible))
    {
        // at least one box visible
    }
    // or:
    if (pictureBoxes.All(box => box.Visible))
    {
        // all boxes visible
    }
