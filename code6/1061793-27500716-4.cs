    private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
    {
            // for testing I turn on every other item; 
            // you will want to use another way to decide..!!
            bool CONDITIONISTRUE = e.Index % 2 == 0;;
            bool selected = listBox1.SelectedIndex == e.Index;
        
            Color col = new Color();
            if (CONDITIONISTRUE)
                col = selected ? SystemColors.HotTrack : Color.PaleGreen;
            else
                col = selected ? SystemColors.HotTrack : Color.Gold;
            e.DrawBackground();           // not really needed
            e.DrawFocusRectangle();       // not really needed either
            using (Pen pen = new Pen(col))
            using (SolidBrush brush = new SolidBrush(col))
            {
              e.Graphics.DrawRectangle(new Pen(col), e.Bounds);
              e.Graphics.FillRectangle(new SolidBrush(col), e.Bounds);
            }
            if (e.Index >= 0)
            {
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), 
                           e.Font, selected? Brushes.White:Brushes.Black, 
                           e.Bounds, StringFormat.GenericDefault);            }
        }
    }
