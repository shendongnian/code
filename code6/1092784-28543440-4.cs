    private void pb_target_MouseMove(object sender, MouseEventArgs e)
    {
        for (int i = 0; i < segments.Count; i++)
        {
            GraphicsPath gp = segments[i];
            if (gp.IsVisible(e.Location))
            {
                Text = "Inside segment #" + i; 
                break;
            }
            else Text = "Outside of the Circle";
        }
    }
