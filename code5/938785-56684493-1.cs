	public GridLength Height
	{
        // Create the "GridLength" from the separate properties
		get => new GridLength(this.Height_Value, (GridUnitType)Enum.Parse(typeof(GridUnitType), this.Height_GridUnitType));
		set
		{
            // store the "GridLength" properties in separate properties
			this.Height_GridUnitType = value.GridUnitType.ToString();
			this.Height_Value = value.Value;
		}
	}
	public string Height_GridUnitType { get; set; }
	public double Height_Value{ get; set; }
