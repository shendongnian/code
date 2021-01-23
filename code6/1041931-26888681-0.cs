    internal DateTime? AddedOnDateEF
        {
            get
            {
                if (!this.AddedOn.HasValue)
                    return null;
                return this.AddedOn.Value.DateTime;
            }
            set
            {
                if (!value.HasValue)
                    this.AddedOn = null;
                else
                {
                    this.AddedOn = new DateTimeOffset(value.Value);
                }
            }
        }
