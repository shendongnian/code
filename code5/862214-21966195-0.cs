    var controller = new SharpDX.XInput.Controller(SharpDX.XInput.UserIndex.One);
    if (controller.IsConnected)
    {
        var state = controller.GetState();
        var x = state.Gamepad.LeftThumbX;
        var y = state.Gamepad.LeftThumbY;
    }
