    public string Status
        {
            get
            {
                decimal _min = Convert.ToDecimal(this.SetMin);
                decimal _max = Convert.ToDecimal(this.SetMax);
                string _status = string.Empty;
                if (this.QtyOnHand < _min)
                    _status = "whatever the status is that means not enough on hand.";
                if(this.QtyOnHand > _max)
                    _status = "whatever the status is that means too much is on hand.";
                return _status;
            }
        }
