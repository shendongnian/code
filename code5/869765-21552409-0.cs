    public void IncerseHeightTextBox(TextBox tb, float Aspect_Ratio_Height)
        {
            tb.AutoSize = false;
            tb.Width = (int)(tb.Width * (1.402+1.171)/2); //Width+height Ratio /2
            tb.Font = new Font(tb.Font.FontFamily, tb.Font.Size * Aspect_Ratio_Height);
            tb.Size = new Size(tb.Width, (int)(tb.Height * Aspect_Ratio_Height));
        }
