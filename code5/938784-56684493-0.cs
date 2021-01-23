	public GridLength Height
	{
		get => new GridLength(this.Height_Value, (GridUnitType)Enum.Parse(typeof(GridUnitType), this.Height_GridUnitType));
		set
		{
			this.Height_GridUnitType = value.GridUnitType.ToString();
			this.Height_Value = value.Value;
		}
	}
	public string Height_GridUnitType { get; set; }
	public double Height_Value{ get; set; }
