    string color
    string polyColor;
    int opacity;
    decimal percentOpacity;
    string opacityString;
    //This allows the user to set the color with a colorDialog adding the chosen color to a string in HEX (without opacity (BBGGRR))
    private void btnColor_Click(object sender, EventArgs e)
    {
        if (colorDialog1.ShowDialog() == DialogResult.OK)
        {
            btnColor.BackColor = colorDialog1.Color;
            Color clr = colorDialog1.Color;
            color = String.Format("{0:X2}{1:X2}{2:X2}", clr.B, clr.G, clr.R);
        }
    }
    //This method takes the Opacity (0% - 100%) set by a textbox and gets the HEX value. Then adds Opacity to Color and adds it to a string.
    private void PolyColor()
    {
        percentOpacity = ((Convert.ToDecimal(txtOpacity.Text) / 100) * 255);
        percentOpacity = Math.Floor(percentOpacity);  //rounds down
        opacity = Convert.ToInt32(percentOpacity);
        opacityString = opacity.ToString("x");
        polyColor = opacityString + color;
    }
