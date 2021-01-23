        protected override void OnStart(string[] args)
        {           
            string timerInterval = ConfigurationManager.AppSettings["TimeInterval"];
            timer = new Timer();
            timer.AutoReset = false;
            timer.Interval = Convert.ToDouble(timerInterval);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(this.TimerTick);
            timer.Start();          
        }
        private void TimerTick(object sender, ElapsedEventArgs e)
        {
            EmployeeManagementService resourceMgmt = new EmployeeManagementService ();
            resourceMgmt.AutoAllocateSalary();
            
            ((Timer)sender).Start();
        }
