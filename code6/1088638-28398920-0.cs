    for (int i = 0; i < 8; i++)
    {
        var block = InterfaceUtils.FindBlock(Utilities.RoundToInt(cam.Position + (cam.lookat * i)));
        if (block != null)
        {
            // Draw the wireframe
        }
    }
