    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
            bool CONDITIONISTRUE = e.Index % 2 == 0;;
            Color col = new Color();
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (CONDITIONISTRUE)
                col = Color.Green;
            else
                col = Color.Yellow;
            using (Pen pen = new Pen(col))
              e.Graphics.DrawRectangle(new Pen(col), e.Bounds);
            e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);
            if (e.Index >= 0)
            {
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, 
                           Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            }
        }
    }
