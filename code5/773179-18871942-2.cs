    foreach (var pb in groupBox1.Controls.OfType<PictureBox>()
                   .OrderBy(x => Int32.Parse(x.Name.Substring("picturebox".Length))))
    {
        pb.Image = ...;
    }
