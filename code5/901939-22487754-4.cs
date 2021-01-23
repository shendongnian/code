    public string Distance
        {
            get
            {
                if(this.InvokeRequired)
                {
                    return (string)this.Invoke((MethodInvoker)(() => this.GetDistance()));
                }
                return this.GetDistance();
            }
        }
        string GetDistance()
        {
            return cbo_DistanceMeasure.SelectedValue.ToString();
        }
