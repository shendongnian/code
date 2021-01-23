    void item_DrawItem(object sender, DrawItemEventArgs e)
            {
                MenuItem cmb = sender as MenuItem;
                string color = SystemColors.Window.ToString();
                if (e.Index > -1)
                {
                    color = cmb.Text;
                }
                if (checkHtmlColor(color))
                {
    
                    e.DrawBackground();
                    e.Graphics.FillRectangle(new SolidBrush(ColorTranslator.FromHtml(color)), e.Bounds);
    
                    e.Graphics.DrawString(color, new Font("Lucida Sans", 10), new SolidBrush(ColorTranslator.FromHtml(color)), e.Bounds);
    
                }
            }
