    Slider[] sliders = new Slider[numOfCheeseMonkeys];
    for (int i =0; i < numOfCheeseMonkeys; i++)
    {
        sliders[i] = GUI.HorizontalSlider(new Rect(25, 50+(i*30), 150, 25), slider[i], 0.0F,   100.0F); // yeah, this doesn't work
    }
