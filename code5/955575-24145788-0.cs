        public void clearOtherDays(int day)
		{
			if ( day != 1)
			{ rbB1.Checked = false; rbL1.Checked = false; rbD1.Checked = false; rbS1.Checked = false;}
			if (day != 2)
			{ rbB2.Checked = false; rbL2.Checked = false; rbD2.Checked = false; rbS2.Checked = false;}
			if (day != 3)
			{ rbB3.Checked = false; rbL3.Checked = false; rbD3.Checked = false; rbS3.Checked = false;}
			if (day != 4)
			{ rbB4.Checked = false; rbL4.Checked = false; rbD4.Checked = false; rbS4.Checked = false;}
			if (day != 5)
			{ rbB5.Checked = false; rbL5.Checked = false; rbD5.Checked = false; rbS5.Checked = false;}
			if (day != 6)
			{ rbB6.Checked = false; rbL6.Checked = false; rbD6.Checked = false; rbS6.Checked = false;}
			if (day != 7)
			{ rbB7.Checked = false; rbL7.Checked = false; rbD7.Checked = false; rbS7.Checked = false;}
		}
		public void getRadioButtonDayNo(string Day)
		{
			int day;
			day = Int32.Parse(Day.Substring(3, 1));
			clearOtherDays(day);
		}
		private void rbL1_CheckedChanged(object sender, EventArgs e)
		{
			if (rbL1.Checked) { string dayNo = rbL1.Name.ToString(); getRadioButtonDayNo(dayNo); }
		}
