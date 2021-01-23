    private void keyPressed(object sender, PreviewKeyDownEventArgs e)
    {
        e.KeyCode == Key.A; // True (pressed A)
        e.KeyCode == Key.Control; // False (no key pressed)
        e.Modifiers == Keys.Control; // True (user is pressing the modifier CTRL)
        e.KeyCode == Key.A && e.Modifiers == Keys.Control; (pressed key A with modifier CTRL)
    }
