        static 
            int
            x1,y1,x2,y2, x3, y3;//for the 3th particule
        private void timer1_Tick_1(object sender, EventArgs e)
        {Moveu();
            Invalidate();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
        
        public Form1()
        {
            InitializeComponent();
            Paint += new PaintEventHandler(paint);
            MouseDown += new MouseEventHandler(mouse_Click);
            MouseUp += new MouseEventHandler(mouse_up);
            MouseMove += new MouseEventHandler(mouse_move);
            //                          x  y  z     vx   vy  vz    m   
            particles[0] = new Particle( 0, 0, 0,    0,  0, 0,    1   ) ;  //sun
            particles[1] = new Particle( 1, 0, 0,    0,  6, 0,    0.03 );   //earth
         // particles[2] = new Particle( 0, 2, 0,    0,  0, 0,    1   );   //planet
         
                    x1 = (int)(100 * particles[0].r[0] + 300);
                    y1 = (int)(100 * particles[0].r[1] + 300);
                    x2 = (int)(100 * particles[1].r[0] + 300);
                    y2 = (int)(100 * particles[1].r[1] + 300);
        }
        Particle[] particles = new Particle[2];
           
        void Moveu()
        {
            double h, t;
            //  setting initial values, step size and max time tmax
            h = 0.005;   // the step size in years
        
            // initial time        
            t = 0;
                    //updates position of --all-- particles   ( z=0 not z=1 )
                    for (int z = 0; z < particles.Length; z++)
                    particles[z].RungeKutta4(particles, t, h, z);
     
                    x1 = (int)(100 * particles[0].r[0] + 300);  //  +300 just for render it in centre
                    y1 = (int)(100 * particles[0].r[1] + 300);
                    x2 = (int)(100 * particles[1].r[0] + 300);
                    y2 = (int)(100 * particles[1].r[1] + 300);
                 // x3 = (int)(100 * particles[2].r[0] + 300);
                 // y3 = (int)(100 * particles[2].r[1] + 300);
        }
        void paint(object s, PaintEventArgs e)
        {
            Graphics graf;
            graf = CreateGraphics();
            graf.FillEllipse(new SolidBrush(Color.AntiqueWhite), x1 + move.X, y1 + move.Y, 50, 50);
            graf.FillEllipse(new SolidBrush(Color.Blue),         x2 + move.X, y2 + move.Y, 10, 10);
       //   graf.FillEllipse(new SolidBrush(Color.Yellow), x3, y3, 20, 20);
        }
        class Particle
        {
            public double[] r;       // position vector
            public double[] v;       // velocity vector
            public double mass;
            //constructor
            public Particle() { }
            public Particle(double x, double y, double z, double vx, double vy, double vz, double m)
            {
                this.r = new double[3];
                this.v = new double[3];
                this.r[0] = x;
                this.r[1] = y;
                this.r[2] = z;
                this.v[0] = vx;
                this.v[1] = vy;
                this.v[2] = vz;
                this.mass = m;
            }
         
            private double acc(double r, Particle[] particles, int particleNumber, double[] r_temp, int l)
            {
                // dv/dt = f(x) = -G * m_i * (x - x_i) / [(x - x_i)^2 + (y - y_i)^2 + (z - z_i)^2]^(3/2)
                double sum = 0;
                switch (l)
                {
                    case 0:
                        for (int i = 0; i < particles.Length; i++)
                            if (i != particleNumber)
                                sum += particles[i].mass * (r - particles[i].r[l]) / Math.Pow(Math.Pow(r - particles[i].r[l], 2)
                                    + Math.Pow(r_temp[1] - particles[i].r[1], 2) + Math.Pow(r_temp[2] - particles[i].r[2], 2), 1.5);
                        break;
                    case 1:
                        for (int i = 0; i < particles.Length; i++)
                            if (i != particleNumber)
                                sum += particles[i].mass * (r - particles[i].r[l]) / Math.Pow(Math.Pow(r - particles[i].r[l], 2)
                                    + Math.Pow(r_temp[0] - particles[i].r[0], 2) + Math.Pow(r_temp[2] - particles[i].r[2], 2), 1.5);
                        break;
                    case 2:
                        for (int i = 0; i < particles.Length; i++)
                            if (i != particleNumber)
                                sum += particles[i].mass * (r - particles[i].r[l]) / Math.Pow(Math.Pow(r - particles[i].r[l], 2)
                                    + Math.Pow(r_temp[0] - particles[i].r[0], 2) + Math.Pow(r_temp[1] - particles[i].r[1], 2), 1.5);
                        break;
                }
                return -G * sum;
            }
            public void RungeKutta4(Particle[] particles, double t, double h, int particleNumber)
            {
                //current position of the particle is saved in a vector
                double[] r_temp = new double[3];
                for (int j = 0; j < 3; j++)
                    r_temp[j] = this.r[j];
                //loop going over all the coordinates and updating each using RK4 algorithm
                for (int l = 0; l < 3; l++)
                {
                    double[,] k = new double[4, 2];
                    k[0, 0] = this.v[l];                                                                //k1_r
                    k[0, 1] = acc(this.r[l], particles, particleNumber, r_temp, l);                     //k1_v
                    k[1, 0] = this.v[l] + k[0, 1] * 0.5 * h;                                            //k2_r
                    k[1, 1] = acc(this.r[l] + k[0, 0] * 0.5 * h, particles, particleNumber, r_temp, l); //k2_v
                    k[2, 0] = this.v[l] + k[1, 1] * 0.5 * h;                                            //k3_r
                    k[2, 1] = acc(this.r[l] + k[1, 0] * 0.5 * h, particles, particleNumber, r_temp, l); //k3_v
                    k[3, 0] = this.v[l] + k[2, 1] * h;                                                  //k4_r
                    k[3, 1] = acc(this.r[l] + k[2, 0] * h, particles, particleNumber, r_temp, l);       //k4_v
                    this.r[l] += (h / 6.0) * (k[0, 0] + 2 * k[1, 0] + 2 * k[2, 0] + k[3, 0]);
                    this.v[l] += (h / 6.0) * (k[0, 1] + 2 * k[1, 1] + 2 * k[2, 1] + k[3, 1]);
                }
            }
           
        }
        public static double G = 4 * Math.PI * Math.PI;   //then time unite in years and length unite = distance between Earth and Sun and masse is the sun masse unite
        void mouse_Click(object o, MouseEventArgs e)
        {
            dwn = new Point(e.X, e.Y);
            if ("" + e.Button == "Left")
            {
                pos = move;
                clicked = true;
            }
        }
        void mouse_move(object o, MouseEventArgs e)
        {
            if (clicked)
            {
                move = new Point(e.X + pos.X - dwn.X, e.Y + pos.Y - dwn.Y);
                Invalidate();
            }
        }
        void mouse_up(object o, MouseEventArgs e)
        {
            clicked = false;
        }
        Point dwn, pos,move;
        bool clicked;
    }`you need to create a Timer and a button [![enter image description here][1]][1]
