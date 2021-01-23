        var sb = new StringBuilder();
        if (Keyboard.PrimaryDevice.IsKeyDown(Key.RightAlt))
            sb.Append("RIGHT ALT ");
        if (Keyboard.PrimaryDevice.IsKeyDown(Key.LeftAlt))
            sb.Append("LEFT ALT ");
        if (Keyboard.PrimaryDevice.IsKeyDown(Key.LeftShift))
            sb.Append("LEFT SHIFT ");
        if (Keyboard.PrimaryDevice.IsKeyDown(Key.RightShift))
            sb.Append("RIGHT SHIFT ");
        if (Keyboard.PrimaryDevice.IsKeyDown(Key.LeftCtrl))
            sb.Append("LEFT CTRL ");
        if (Keyboard.PrimaryDevice.IsKeyDown(Key.RightCtrl))
            sb.Append("RIGHT CTRL ");
        Debug.Print(sb.ToString());
