     using (var ms = new System.IO.MemoryStream(q_pic)) {
        using(var img = Image.FromStream(ms)) {
           pictureBox1.Image = img;
        }
     }
