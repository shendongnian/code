    class Form
    {
        bool _inCheatMode = false;
        Ball ball;
        void EnterCheatMode()
        {
            _inCheatMode = true;
            ball.SetSpeed(0, 0); //stop the ball
        }
        void ExitCheatMode()
        {
            _inCheatMode = false;
        }
        void KeyDown(Keys key)
        {
            if (_inCheatMode)
            {
                if (key == Keys.Up)
                   ball.SetSpeed(0, -1);
            }
        }
    }
    class Ball
    {
        public void SetSpeed(x, y)
        {
        }
    }
