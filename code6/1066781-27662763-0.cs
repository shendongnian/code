    while (m.Success) {
        string new_s = str.Substring(m.Index);
        string new_p = "</" + m.Groups["tag"].Value + ">";
        Match m_end = Regex.Match(new_s, new_p);
        Point start_p = textBox1.GetPositionFromCharIndex(m.Index);
        Point end_p = textBox1.GetPositionFromCharIndex(m_end.Index + m.Index);
        int top = (int)start_p.Y;
        int bottom = (int)(end_p.Y + textBox1.Font.Size);
        if (m_end.Success) {
            int midpoint = (top + bottom) / 2;
            PictureBox pictureBox = new PictureBox();
            pictureBox.Name = "pictureBox" + i.ToString();
            pictureBox.Location = new System.Drawing.Point(15, midpoint + 7 + 2);
            pictureBox.Image = Image.FromFile("c:\\blob.png");
            pictureBox.Size = new Size(15, 15);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pictureBox);
        }
        i++;
        m = r.Match(str, m_end.Index + m.Index);
    }
