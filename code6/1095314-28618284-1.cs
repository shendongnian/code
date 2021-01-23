    string prefix = "picDog";
    foreach (PictureBox pictureBox in Controls.OfType<PictureBox>())
    {
        if (pictureBox.Name.StartsWith(prefix))
        {
            int index;
            if (int.TryParse(pictureBox.Name.Substring(prefix.Length), out index))
            {
                dogs[index] = pictureBox;
            }
        }
    }
