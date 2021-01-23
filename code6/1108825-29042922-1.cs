    private void farv(int x, int y)
    {
        var buttonName = string.Format("bt{0}{1}", x + 1, y + 1);
        var buttonControl = Controls.Find(buttonName, true).FirstOrDefault();
        if (buttonControl != null)
        {
            buttonControl.BackColor = GetColorForPlayer(playerValue);
        }
    }
    private Color GetColorForPlayer(int playerValue)
    {
        Color defaultColor = SystemColors.Control;
        switch (playerValue)
        {
            case 1:
                return Color.Blue;
            case 10:
                return Color.Red;
            default:
                return defaultColor;
        }
    }
