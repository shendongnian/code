       private List<DateTime> ValidEndTime = new List<DateTime>(); //Contains the list of validEndDate 
        private void button1_Click(object sender, EventArgs e)
        {
            List<DateTime> currentAppointment = new List<DateTime>();
            currentAppointment.Add(Convert.ToDateTime("22 May 2014 14:22"));
            currentAppointment.Add(Convert.ToDateTime("22 May 2014 14:30"));
            foreach (DateTime endDate in currentAppointment)
            {
                if (IsAppointmentTimeValid(endDate) == true)
                {
                    ValidEndTime.Add(endDate);
                }    
            }     
        }
        private bool IsAppointmentTimeValid(DateTime newAppointmentEndTime)
        {
            //compare max(maxendDateTime) with the newAppointmentDateTime
            return ValidEndTime.Max(t => t.Date) < newAppointmentEndTime? true : false;
        }
