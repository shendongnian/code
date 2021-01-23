    public partial class Form1 : Form
    {
        private List<Peça> peças;
        private Point _Offset = Point.Empty;
        private Peça peça1, peça2, peça3, peça4;
        private bool canMove;
        private Peça atual;
        private bool other=false;
        public Form1()
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
            InitializeComponent();
            atual = new Peça();
            peça1 = new Peça();
            peça2 = new Peça();
            peça3 = new Peça();
            peça4 = new Peça();
            peça1.imagem = Properties.Resources._4p1_1;
            peça2.imagem = Properties.Resources._4p1_2;
            peça3.imagem = Properties.Resources._4p1_3;
            peça4.imagem = Properties.Resources._4p1_4;
            peças = new List<Peça>();
            peça1.Name = "peça1";
            peça2.Name = "peça2";
            peça3.Name = "peça3";
            peça4.Name = "peça4";
            this.Controls.Add(peça1);
            this.Controls.Add(peça2);
            this.Controls.Add(peça3);
            this.Controls.Add(peça4);
            criaListaPecas();
            foreach (Peça p in peças)
            {
                p.Size = new Size(p.imagem.Width, p.imagem.Height);
            }
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
            
            associaEventosPecas();
            canMove = false;
        }
        private void associaEventosPecas()
        {
            foreach (Peça p in peças)
            {
                p.MouseMove += Form1_MouseMove;
                p.MouseDown += Form1_MouseDown;
                p.MouseUp += Form1_MouseUp;
            }
        }
        private void criaListaPecas()
        {
            peças.Clear();
            foreach (Control p in this.Controls)
            {
                if (p.GetType() == typeof(Peça))
                    peças.Add((Peça)p);
            }
            Console.WriteLine(peças[0].Name);
            Console.WriteLine(peças[1].Name);
            Console.WriteLine(peças[2].Name);
            Console.WriteLine(peças[3].Name);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;
                return handleParam;
            }
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender.GetType().Equals(typeof(Peça)))
            {
                label1.Text = new Point(e.Location.X + (sender as Peça).Location.X, e.Location.Y + (sender as Peça).Location.Y).ToString();
            }
            else
            label1.Text = e.Location.ToString();
            gereMovimento(sender, e);
        }
        private void gereMovimento(object sender, MouseEventArgs e)
        {
            if (canMove)
            {
                if (other)
                {
                    Point p = atual.PointToClient(new Point(e.X + (sender as Peça).Location.X, e.Y + (sender as Peça).Location.Y));
                    Point newlocation = atual.Location;
                    newlocation.X += p.X - _Offset.X;
                    newlocation.Y += p.Y - _Offset.Y;
                    atual.Location = newlocation;
                }
                else
                {
                    Point newlocation = atual.Location;
                    newlocation.X += e.X - _Offset.X;
                    newlocation.Y += e.Y - _Offset.Y;
                    atual.Location = newlocation;
                }
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender.GetType().Equals(typeof(Peça)) && e.Button == MouseButtons.Left)
            {
                atual = sender as Peça;
                atual.BringToFront();
                criaListaPecas();
                if (atual.Down(e.Location))
                {
                    _Offset = new Point(e.X, e.Y);
                    canMove = true;
                    other = false;
                }
                else
                {
                    Console.WriteLine(peças[1].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y)));
                    Console.WriteLine(atual.Location);
                    Point p = new Point(); 
                    if (peças[1].ClientRectangle.Contains(peças[1].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y)))
                        && peças[1].Down(peças[1].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y))))
                    {
                        p = peças[1].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y));
                        atual = peças[1];
                        atual.BringToFront();
                        criaListaPecas();
                        _Offset = p;
                        canMove = true;
                        other = true;
                    }
                    else if (peças[2].ClientRectangle.Contains(peças[2].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y)))
                        && peças[2].Down(peças[2].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y))))
                    {
                        p = peças[2].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y));
                        atual = peças[2];
                        atual.BringToFront();
                        criaListaPecas();
                        _Offset = p;
                        canMove = true;
                        other = true;
                    }
                    else if (peças[3].ClientRectangle.Contains(peças[3].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y)))
                        && peças[3].Down(peças[3].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y))))
                    {
                        p = peças[3].PointToClient(new Point(e.X + atual.Location.X, e.Y + atual.Location.Y));
                        atual = peças[3];
                        atual.BringToFront();
                        criaListaPecas();
                        _Offset = p;
                        canMove = true;
                        other = true;
                    }
                }
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            canMove = false;
        }
    }
