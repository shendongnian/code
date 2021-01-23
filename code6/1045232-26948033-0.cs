    foreach (string fileName in openFileDialog.FileNames)
    {
        circleDetection examDetect = new circleDetection();
        using (Bitmap tempImage = new Bitmap(fileName))
        {
            Exam.Add(tempImage);
            directory.Text = fileName;
            PictureBox picBox = new PictureBox();
            picBox.Width = 200;
            picBox.Height = 200;
            picBox.Location = new System.Drawing.Point(picBoard.Controls.Count * (picBox.Width + 5) + 5, 5);
            picBox.SizeMode = PictureBoxSizeMode.Zoom;
            picBox.BorderStyle = BorderStyle.FixedSingle;
            examDetect.ProcessImage(tempImage);
            picBox.Image = examDetect.getImage();
            Console.WriteLine(i++);
            student.Add(compare(examDetect));
            picBoard.Controls.Add(picBox);
        }
    }
