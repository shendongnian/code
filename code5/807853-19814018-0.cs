        private void drawArray(int[] arr, PictureBox box)
        {
            using (Graphics g = Graphics.FromImage(drawArea))
            {
                Pen mypen = new Pen(Brushes.Black);
                g.Clear(Color.White);
                for (int i = 0; i < arr.Length; i++)
                    g.DrawLine(mypen, i * 2, drawArea.Height,
                      i * 2, drawArea.Height - arr[i]);
            }
            box.Invalidate();
        }
