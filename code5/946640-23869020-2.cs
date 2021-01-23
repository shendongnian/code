     public List<PictureBox> Tablenm(int n, int m)
     {
            for (int i = 0; i < n*m; i++)
            {
                PictureBox pict = new PictureBox();
                cell.Add(pict);
                cell[i].Size = new Size(20, 20);
                cell[i].Location = new Point(30 + (i % n) * 19, 30 + (i / m) * 19);
                cell[i].Image = Properties.Resources.lang20x20;
            }
            return cell;
     }
