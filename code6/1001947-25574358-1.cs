		public int RecordPosition
		{
			get
			{
				return this._position;
			}
			set
			{
				this._position = value;
				this.SendChange("RecordPosition");
			}
		}
