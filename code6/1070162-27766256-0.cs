    private void list_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
    {
        using (var sf = new StringFormat())
        {
            sf.Alignment = StringAlignment.Center;
            
            using (var headerFont = new Font("Microsoft Sans Serif", 9, FontStyle.Bold))
            {
                e.Graphics.FillRectangle(Brushes.Pink, e.Bounds);
                e.Graphics.DrawString(e.Header.Text, headerFont, 
                    Brushes.Black, e.Bounds, sf);
            }
        }
    }
