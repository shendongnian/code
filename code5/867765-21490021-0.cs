        private string _country;
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Country", CanBeNull=false)]
		public string Country
		{
			get
			{
                return this._country;
			}
			set
			{
                if ((this._country != value))
				{
                    this._country = value;
				}
			}
		}
