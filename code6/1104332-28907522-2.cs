		public void Main()
		{
            bool fireAgain = false;
            this.Dts.Events.FireInformation(0, "my sub", "info", string.Empty, 0, ref fireAgain);
            // Note, no cancel available
            this.Dts.Events.FireError(0, "my sub", "error", string.Empty, 0);
		}
