    using OpenTK;
    using OpenTK.Input;
    class MouseControls
    {
        public float Yaw { get; set; }
        public float Pitch { get; set; }
        public float Offset { get; set; }
        public float Scale { get; set; }
    
        MouseState mouse_previous;
    
        public void Update()
        {
            var mouse = Mouse.GetState();
            var delta = new Vector3(
                mouse.X - mouse_previous.X,
                mouse.Y - mouse_previous.Y,
                mouse.WheelPrecise - mouse_previous.WheelPrecise);
    
            if (mouse[MouseButton.Left] && !mouse[MouseButton.Right])
            {
                Yaw -= delta.X;
                Pitch -= delta.Y;
            }
    
            if (mouse[MouseButton.Left] && mouse[MouseButton.Right])
            {
                Offset += delta.Y;
            }
    
            Scale -= Scale * MathHelper.Clamp(delta.Z, -1.0f, 1.0f);
            Scale = Scale < 0.01f ? 0.01f : Scale;
        }
    }
