        /// <summary>
		/// Mouse Down Event
		/// </summary>
		private void Chart1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Call Hit Test Method
			HitTestResult result = Chart1.HitTest( e.X, e.Y );
			
			if( result.ChartElementType == ChartElementType.AxisLabels && result.Axis == Chart1.ChartAreas["Default"].AxisY )
			{
				StripLine stripLine = new StripLine();
				stripLine.IntervalOffset = ((CustomLabel) result.Object).FromPosition;
				stripLine.Interval = 200;
				stripLine.BackColor = Color.FromArgb(128, 255,255, 255);
				stripLine.StripWidth = ((CustomLabel) result.Object).ToPosition - ((CustomLabel) result.Object).FromPosition;
				Chart1.ChartAreas["Default"].AxisY.StripLines.Add( stripLine );
			}
		
		}
