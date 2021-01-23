    public class Form1:Form
    {
        public enum CalcStatus
        {
			None,
            Plus,
            Minus,
            Divide,
            Multiply
        };
        CalcStatus status = CalcStatus.None;
		bool bHasNewFlag = false;
		bool bHasEquals = false;
		Decimal dMemory1 = 0M;
		Decimal dMemory2 = 0M;
        private void CalcButton_Click(object sender, EventArgs e) // This event will be handled by Plus,Minus,Devide and Multiply
        {
			Decimal.TryParse(txtDisplay.Text,out dMemory1);
            switch(((button)sender).Text)
			{
				case "+":
					status = CalcStatus.Plus;
					break;
				case "-":
					status = CalcStatus.Minus;
					break;
				case "/":
					status = CalcStatus.Divide;
					break;
				case "*":
					status = CalcStatus.Multiply;
					break;
			}
			bHasNewFlag = true;
			bHasEquals =false;
			dMemroy2 = 0M;
        }
		private void NumButton_Click(object sender, EventArgs e) // This event will be handled by numbers (0-9)
		{
			int iNumber = 0;
			int.TryParse(((button)sender).Text, out iNumber);
			if (bHasNewFlag)
				txtDisplay.Text = string.empty;
			txtDisplay.Text += iNumber.ToString();
			bHasEquals =false;
			dMemroy2 = 0M;
		}
		private void EqualsTo_Click(object sender, EventArgs e) // This event will be handled by Equals To (=)
		{
			Decimal dVal = 0M;
			
			if (bHasEquals == false)
				Decimal.TryParse(txtDisplay.Text, out dMemory1);
			
			switch(status)
			{
				case "+":
					dVal = dMemory1 + dMemory2;
					break;
				case "-":
					status = CalcStatus.Minus;
					dVal = dMemory1 - dMemory2;
					break;
				case "/":
					dVal = dMemory1 / dMemory2;
					break;
				case "*":
					dVal = dMemory1 * dMemory2;
					break;
			}
			txtDisplay.Text = dVal;
			bHasEquals =true;			
		}
    }
