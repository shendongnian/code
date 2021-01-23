     private Color GetARGBValues(int value)
     {
        byte[] temp = new byte[4];
        temp[0] = System.Drawing.Color.FromArgb(value).A;
        temp[1] = System.Drawing.Color.FromArgb(value).R;
        temp[2] = System.Drawing.Color.FromArgb(value).G;
        temp[3] = System.Drawing.Color.FromArgb(value).B;
        return Color.FromArgb(temp[0], temp[1], temp[2], temp[3]);
    }
