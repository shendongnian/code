    public class Table
    {
        public List<PictureBox> Render(int n, int m)
        {
            List<PictureBox> returnList = new List<PictureBox>();
            for (int i = 0; i < n*m; i++)
            {
                PictureBox pict = new PictureBox();
                pict.Size = new Size(20, 20);
                pict.Location = new Point(30 + (i % n) * 19, 30 + (i / m) * 19);
                pict.Image = Properties.Resources.lang20x20;
                returnList.Add(pict);
            }
            return returnList;
        }
    }
