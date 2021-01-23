        int spacing = 100;
    int zero = 0;
    for (int z = 1; z <= 4; z++)
    {
        List<string> zString = new List<string>();
        for (int y = 1; y <= 4; y++)
        {
            for (int x = 1; x <= 4; x++)
            {
                int pixel_x =  zero + ((x - 1) * spacing);
                int pixel_y =  zero + ((y - 1) * spacing);
                CheckBox box = new CheckBox();
                box.Margin = new Thickness(pixel_x, pixel_y, 0, 0);
                this.grid.Children.Add(box);
            }
        }
        zero = zero + 50;
    }
