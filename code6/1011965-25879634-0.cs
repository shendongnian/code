    public DateTime? NullableExp_dt
    {
        get
        {
            if (this.IsExp_dtNull())
            {
                return (DateTime?) null;
            }
            else
            {
                return (DateTime?) this.Exp_dt;
            }
        }
        set
        {
            if (value.HasValue())
            {
                this.Exp_dt = value.Value;
            }
            else
            {
                this.SetExp_dtNull();
            }
        }
    }
