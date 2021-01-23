     public partial class Form1 : Form
    {
        Timer timer = new Timer();
        int curX = 0;
        Timer valueInsertingTimer = new Timer();
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Paint += pictureBox1_Paint;
            timer.Interval = 10;
            timer.Tick += timer_Tick;
            timer.Start();
            valueInsertingTimer.Interval = 30;
            valueInsertingTimer.Tick += valueInsertingTimer_Tick;
            valueInsertingTimer.Start();
        }
        void valueInsertingTimer_Tick(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int num = rnd.Next(80);
            addY(num);
        }
        void addY(int val)
        {
            if (Ys.Count > 0)
            {
                int lastY = Ys[Ys.Count - 1];
                if (val > lastY)
                {
                    for (int i = lastY; i < val; i++)
                    {
                        Ys.Add(i);
                        Xs.Add(curX += 1);
                    }
                }
                else if (val < lastY)
                {
                    for (int i = lastY; i > val; i--)
                    {
                        Ys.Add(i);
                        Xs.Add(curX += 1);
                    }
                }
                else
                {
                    Xs.Add(curX += 1);
                    Ys.Add(val);
                }
            }
            else
            {
                Ys.Add(1);
                Xs.Add(curX += 1);
            }
            if (Xs.Count > pictureBox1.Width)
            {
                Xs.RemoveAt(0);
                Ys.RemoveAt(0);
                difference++;
            }
        }
        int difference = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }
        List<int> Xs = new List<int>();
        List<int> Ys = new List<int>();
        void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Xs.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.Black, Xs[i] - difference, pictureBox1.Height - Ys[i], 1, 1);
            }
        }
    }
