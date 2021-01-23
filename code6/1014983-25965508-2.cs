		private void TickCounter_ValueChanged(object sender, EventArgs e)
        {
            if (TickCounter.Value > 0)
                tPeriodic.Interval = 1000 / Convert.ToInt32(TickCounter.Value * TickCounter.Value);
            else if (TickCounter.Value < 0)
                tPeriodic.Interval = 1000 * Convert.ToInt32(TickCounter.Value * TickCounter.Value);
            else
                tPeriodic.Interval = 1000;
        }
			
			
