        var sb = new StringBuilder();
        var modifierKeys = Keyboard.PrimaryDevice.Modifiers;
        if (modifierKeys.HasFlag(ModifierKeys.Alt))
            sb.Append("ALT ");
        if (modifierKeys.HasFlag(ModifierKeys.Control))
            sb.Append("CTRL ");
        if (modifierKeys.HasFlag(ModifierKeys.Shift))
            sb.Append("SHIFT ");
        Debug.Print(sb.ToString());
