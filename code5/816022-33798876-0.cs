    _battery = Battery.GetDefault();
    _battery.RemainingChargePercentChanged += OnRemainingChargePercentChanged;
    private void OnRemainingChargePercentChanged(object sender, object e)
    {
       var remainingCharge = string.Format("{0} %", _battery.RemainingChargePercent);
       var remainingTime = _battery.RemainingDischargeTime.TotalMinutes;
      if(Microsoft.Phone.Info.DeviceStatus.PowerSource == Microsoft.Phone.Info.PowerSource.External)
          var text = "Charger Connected";
      else 
          var text = "Charger Not Connected";
    }
