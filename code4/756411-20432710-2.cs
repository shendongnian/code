    var directInput = new DirectInput();
    var joystick = new Joystick(directInput, joystickGuid);
    joystick.Acquire();
    joystick.Properties.BufferSize = 128;
    while (true)
    {
      joystick.Poll();
      var data = joystick.GetBufferedData();
      foreach (var state in data) 
      {
        if (state.Offset == JoystickOffset.X)
        {
           textBox1.Text = state.Value;
        }
      }
    }
