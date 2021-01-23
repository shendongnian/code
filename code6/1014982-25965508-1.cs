			private void TickCounter_ValueChanged(object sender, EventArgs e)
			{
				TickCounter.Value = TickCount;
				if (TickCount > 0)
					tPeriodic.Interval = 1000 / Convert.ToInt32(TickCounter.Value * TickCounter.Value);
				else if (TickCount < 0)
					tPeriodic.Interval = 1000 * Convert.ToInt32(TickCounter.Value * TickCounter.Value);
				else
					tPeriodic.Interval = 1;
			}
			
			
