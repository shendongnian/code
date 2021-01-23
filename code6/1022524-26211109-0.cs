            protected virtual bool CheckForThresholds(long rsValue, long rsLowLimit, long rsUpperLimit)
            {
                EventHandler handler = null;
                if (rsValue < rsLowLimit)
                {
                    handler = BelowLowLimit;
                }
                else if (rsValue > rsUpperLimit)
                {
                    handler = AboveHighLimit;
                }
                if (handler != null)
                {
                    handler(this, new EventArgs());
                    return true;
                }
    
                return false;
            }
    
            public long Rs
            {
                get { return rs.Value; }
                set
                {
                    if (!CheckForThresholds(value, rs.LowLimit, rs.UpperLimit))
                    {
                        this.rs.Value = value;
                    }
                }
            }
