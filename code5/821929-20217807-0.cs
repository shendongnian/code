    public Battery(string model, int hoursidle, int hourstalk, BatteryType? batteryType)
    {
        this.Model = model;
        this.HoursIdle = hoursidle;
        this.HoursTalk = hourstalk;
        if(batteryType.HasValue)
            this.BatteryType = batteryType.Value;
    
    }
