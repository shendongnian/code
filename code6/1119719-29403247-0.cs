        public decimal DifferenceA
		{
			get
			{
				return this.PrevCalcA - this.ItemA.Value - this.CalcA;
			}
		}
		
        public decimal DifferenceB
		{
			get
			{
				return this.PrevCalcB - this.ItemB.Value - this.CalcB;
			}
		}
		
        public decimal DifferenceC
		{
			get
			{
				return this.PrevCalcC - this.ItemC.Value - this.CalcC;
			}
		}
