    private void Health_Regen_Tick(object sender, EventArgs e)
    {
        if (ImageNumber1 == 0)
        {
            Health_Regen.Enabled = false;
        }
        else if (ImageNumber1 <= 20)
        {
            ImageNumber1 += 1;
        }
        HealthBar.Image = Image.FromFile(path + ImageNumber1.ToString() + ".png";
    }
