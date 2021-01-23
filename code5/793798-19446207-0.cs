    public class MyForm : Form
    {
        private int deltaX;
        private int deltaY;
        private const int movementAmount = 10;
        private Timer movementTimer = new Timer();
        public MyForm()
        {
            movementTimer.Interval = 100; // make this whatever interval you'd like there to be in between movements
            movementTimer.Tick += new EventHandler(movementTimer_Tick);
        }
        void movementTimer_Tick(object sender, EventArgs e)
        {
            myMonster.Location = new Point(myMonster.X + deltaX, myMonster.Y + deltaY);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        deltaX -=movementAmount;
                    } break;
                case Keys.Right:
                    {
                        deltaX += movementAmount;
                    } break;
                case Keys.Up:
                    {
                        deltaY -= movementAmount;
                    } break;
                case Keys.Down:
                    {
                        deltaY += movementAmount;
                    } break;
            }
            UpdateTimer();
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    {
                        deltaX += movementAmount;
                    } break;
                case Keys.Right:
                    {
                        deltaX -= movementAmount;
                    } break;
                case Keys.Up:
                    {
                        deltaY += movementAmount;
                    } break;
                case Keys.Down:
                    {
                        deltaY -= movementAmount;
                    } break;
            }
            UpdateTimer();
        }
        private void UpdateTimer()
        {
            movementTimer.Enabled = deltaX != 0 || deltaY != 0;
        }
    }
