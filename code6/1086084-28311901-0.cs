				// Add a second legend
				Legend secondLegend = new Legend("Second");
				secondLegend.BackColor = Color.FromArgb(((System.Byte)(220)), ((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(255)));
				secondLegend.BorderColor = Color.Gray;
				secondLegend.Font = this.Chart1.Legends["Default"].Font;
				this.Chart1.Legends.Add(secondLegend);
				// Associate Series 2 with the second legend 
				this.Chart1.Series["Series 2"].Legend = "Second";
