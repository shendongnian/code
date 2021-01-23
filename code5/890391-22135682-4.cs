    namespace stackoverflow.com/questions/22135510
    {
        public partial class Form1 : Form
        {
            public int X_UPPER_LIMIT = 0;
            public int Y_UPPER_LIMIT = 0;
    
            public int X_LOWER_LIMIT = 0; 
            public int Y_LOWER_LIMIT = 0; 
    
            public Point randomPoint = new Point();
            public Point newPosition = new Point();
    
            public Random r = new Random();
    
            public Form1()
            {
                InitializeComponent();
                //care here, remove the pitureBox1.Location effects, if pictureBox is parent to the button
                X_UPPER_LIMIT = pictureBox1.Location.X + pictureBox1.Width - button1.Width - 1
                Y_UPPER_LIMIT = pictureBox1.Location.Y + pictureBox1.Height - button1.Height - 1;
    
                X_LOWER_LIMIT = pictureBox1.Location.X + 1; //set this to 0, if pictureBox is parent of button
                Y_LOWER_LIMIT = pictureBox1.Location.Y + 1; //set this to 0, if pictureBox is parent of button
                timer1.Start();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
            }
    
            private void timer1_Tick(object sender, EventArgs e)
            {
                //first, lets call the randoms at the start of tick
                randomPoint.X = r.Next(X_LOWER_LIMIT, X_UPPER_LIMIT);
                randomPoint.Y = r.Next(Y_LOWER_LIMIT, Y_UPPER_LIMIT);
    
                newPosition.X = button1.Location.X;
                newPosition.Y = button1.Location.Y;
    
                //now, lets update positions, if they are not equal
                if (button1.Location.X != randomPoint.X)
                {
                    if (button1.Location.X > randomPoint.X)
                        newPosition.X--;
                    else
                        newPosition.X++;
                }
    
                if (button1.Location.Y != randomPoint.Y)
                {
                    if (button1.Location.Y > randomPoint.Y)
                        newPosition.Y--;
                    else
                        newPosition.Y++;
                }
    
                button1.Location = newPosition;
            }
        }
    }
