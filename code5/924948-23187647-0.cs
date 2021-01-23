    private void DisplayQueues ( )
		{
			//Redraw textbox
			textBox_Registers.Refresh ( );
			//New string that holds register lines
			String registers = "";
			//Add register headings to string
			registers += FormatHeading ( );
			
			//First loop goes through customers in line, seconds loop goes through lines
			for (int i = 0; i < RegLines[GetLongest ( )].Count; i++)
			{
				for (int n = 0; n < NumRegisters; n++)
				{
					//If more customers in line, add to string
					if (i < RegLines[n].Count)
						registers += String.Format ("{0, -10}", RegLines[n].ToArray()[i].CustomerNum.ToString());
				}
				registers += "\r\n";
			}
			
			textBox_Registers.Text = registers;
		}
