        void CalculateVelocity(List<velocity> ListOfVelocity, particle newprojectile, Environment newEnvironment)
        {
            //load in stats
            newEnvironment.gravity = -9.8;
            newprojectile.TimeOfFlight = Convert.ToDouble(txtbox_TimeOfFlight.Text);
            newprojectile.InitialVelocity.Magnitude = Convert.ToDouble(txtbox_InitialVelocity.Text);
            newprojectile.InitialVelocity.AngleOfTravel = Convert.ToDouble(txtb_AngleOLaunch.Text);
            double TimeInterval;
            double FlightTime =0;
            double InitialHVelocity;
            velocity newVelocity;
            newVelocity = new velocity();
            newVelocity.Magnitude = Convert.ToDouble(txtbox_InitialVelocity.Text);
            newVelocity.AngleOfTravel = Convert.ToDouble(txtb_AngleOLaunch.Text);
            newVelocity.AngleOfTravel = newprojectile.InitialVelocity.AngleOfTravel;
            velocity.CalculateVComponent(newVelocity);
            velocity.CalculateHComponent(newVelocity);
            InitialHVelocity = newVelocity.HorizontalVelocity;
            ListOfVelocity.Add(newVelocity);
            if (newprojectile.TimeOfFlight > 60)
            {
                TimeInterval = newprojectile.TimeOfFlight / 60;
            }
            else
            {
                TimeInterval = 1;
            }
            FlightTime =FlightTime+ TimeInterval;
            while (!(newprojectile.TimeOfFlight < FlightTime))
            {
                newVelocity = (velocity)newVelocity.clone(); // HERE!
                velocity.CalculateVComponent(newVelocity, FlightTime, newEnvironment, newVelocity.VerticleVelocity);
                ListOfVelocity.Add(newVelocity);
                FlightTime = FlightTime + TimeInterval;
            }
        }
