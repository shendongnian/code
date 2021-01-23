            MemoryImage = new Bitmap(panel13.Width, pn1.Height);
            pn1.DrawToBitmap(MemoryImage, new Rectangle(0, 0, pn1.Width, pn1.Height));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            if (MemoryImage != null)
            {
                e.Graphics.DrawImage(MemoryImage, 0, 0);
                base.OnPaint(e);
            }
        }
        void printdoc1_PrintPage(object sender, PrintPageEventArgs e)
        {
           
           
            Rectangle pagearea = e.PageBounds;
            e.Graphics.DrawImage(MemoryImage, (pagearea.Width / 2) - (this.panel13.Width / 2), this.panel13.Location.Y);
        }
 
            Bitmap bmp = new Bitmap(MemoryImage.Width, MemoryImage.Height);
            panel13.DrawToBitmap(bmp, panel13.Bounds);
            saveFileDialog1.ShowDialog();
            saveFileDialog1.Title = "Save";
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
           
            bmp.Save(saveFileDialog1.FileName);
