    bool grabbing = false;
    bool selected = false;
    var button;
    var handElement;
    Start()
    {
        button = window.Button;
        handElement = window.handElement;
        ...
        sensor.Start();
    }
    Update() //all frames ready
    {
        using (SkeletonFrame sf = e.OpenSkeletonFrame())
        {
            ... //get skeleton and position
            ... //tell if grabbing
            if (/*however you do the grab gesture*/)
                grabbing = true;
            if (selected && grabbing)
            {
                button.X = handElement.X;
                button.Y = handElement.Y;
            }
        }
    }
    Button_OnClick()//or whatever it is called for the Kinect UI control
    {
        selected = true;
    }
