     private void LoadStaticsAndStart(object sender, RoutedEventArgs e)
        {
            GraphCanvas.Visibility = Visibility.Visible;
            DrawAxis();
            List<velocity> velocityList = new List<velocity>();
            double[,] DisplacementArray = new double[59, 1];
            btn_Calculate.Click += OnLoaded;
            particle newParticle;
            velocity InitialVelocity = new velocity();
            ObjectsAndDataStuctures.Environment newEnvironment;
            if (FormatCheck(txtb_AngleOLaunch) == false || FormatCheck(txtbox_InitialVelocity) == false || FormatCheck(txtbox_TimeOfFlight) == false)
            {
                MessageBox.Show(" Input is not valid");
            }
            else
            {
                newEnvironment = new ObjectsAndDataStuctures.Environment();
                newEnvironment.gravity = -9.8; // gravity remove when needed or changed
                InitialVelocity.Magnitude = Convert.ToDouble(txtbox_InitialVelocity.Text); // collecting variables.
                InitialVelocity.AngleOfTravel = Convert.ToDouble(txtb_AngleOLaunch.Text); // collecting variables.
                newParticle = new particle(InitialVelocity, Convert.ToDouble(txtbox_TimeOfFlight.Text));
                stk_pnl_inputvar.Visibility = Visibility.Collapsed;
                CreateLabels(newParticle);
                newParticle.CalculateHComponent();
                newParticle.CalculateVComponent();
                MPP(newParticle, newEnvironment);
                OnLoaded(this, e);
                if (Convert.ToDouble(txtbox_TimeOfFlight.Text) > 60)
                {
                    TimeConstant = Convert.ToDouble(txtbox_TimeOfFlight.Text) / 60;
                }
                else
                {
                    TimeConstant = 1;
                }
                double HVelTemp = newParticle.InitialVelocity.HorizontalVelocity * PixelPerMeter;
                double VVelTemp = newParticle.InitialVelocity.VerticalVelocity * PixelPerMeter * -1;
                Velocity = new Vector(HVelTemp, VVelTemp); // y direction is downwards
                acceleration = new Vector(0, -1 * newEnvironment.gravity * PixelPerMeter); // y direction is downwards
                aTimer = new System.Windows.Threading.DispatcherTimer();
                aTimer.Interval = new TimeSpan(0, 0, 0, 0, 200);
                //newParticle.CurrentVelocity = newParticle.InitialVelocity;
                //this.DataContext = this;
                TimerEvent = (s, t) => onTimedEvent(sender, t, newParticle, newEnvironment);
                aTimer.Tick += TimerEvent;
                ListOfVelocities.Add((velocity)newParticle.CurrentVelocity.Clone());
                InSimulation = true;
                aTimer.Start();
            } 
        }
