    var pictureBoxData =
    (
        from x in Enumerable.Range(0, countX)
        from y in Enumerable.Range(0, countY)
        let positionX = x * image.Width
        let positionY = y * image.Height
        let pictureBox = new PictureBox()
        {
            Image = image,
            Location = new Point(positionX, positionY),
            Size = new Size(image.Width, image.Height),
        }
        select new
        {
            positionX,
            positionY,
            pictureBox,
        }
    ).ToList();
