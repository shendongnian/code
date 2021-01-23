    public string EndTimeString
    {
        get
        { 
            string endTime = null;
            if (this.To.HasValue)
            {
                if (this.Type == WorkUnitType.StartEnd)
                {
                    endTime = this.To.Value.ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortTimePattern);
                }
                else
                {
                    var duration = this.To.Value - this.From;
                    endTime = DateHelper.FormatTime(duration, false);
                }        
            }
            return endTime
        }
    }
