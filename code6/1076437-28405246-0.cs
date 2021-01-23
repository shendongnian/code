    /// <summary>
    /// Updates the data.
    /// </summary>
    protected internal override void UpdateData()
    {
        if (this.ItemsSource == null)
        {
            return;
        }
        this.items.Clear();
        // Use the mapping to generate the points
        if (this.Mapping != null)
        {
            foreach (var item in this.ItemsSource)
            {
                this.items.Add(this.Mapping(item));
            }
            return;
        }
        var filler = new ListFiller<HighLowItem>();
        filler.Add(this.DataFieldX, (p, v) => p.X = Axis.ToDouble(v));
        filler.Add(this.DataFieldHigh, (p, v) => p.High = Axis.ToDouble(v));
        filler.Add(this.DataFieldLow, (p, v) => p.Low = Axis.ToDouble(v));
        filler.Add(this.DataFieldOpen, (p, v) => p.Open = Axis.ToDouble(v));
        filler.Add(this.DataFieldClose, (p, v) => p.Close = Axis.ToDouble(v));
        filler.FillT(this.items, this.ItemsSource);
    }
