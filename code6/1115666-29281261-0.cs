    private void Pacman_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Left:
                mouthcurrentposition = 0;
                picFrame.yPosition -= 10;
                picFrame.Left(); //This should be a method that will draw your pacman
                break;
            case Keys.Right:
                mouthcurrentposition = 1;
                picFrame.yPosition += 10;
                picFrame.Right();
                break;
            case Keys.Up:
                mouthcurrentposition = 2;
                picFrame.yPosition -= 10;
                picFrame.Up();
                break;
            case Keys.Down:
                mouthcurrentposition = 3;
                picFrame.yPosition += 10;
                picFrame.Down();
                break;
        }
    }
