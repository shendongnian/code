        var status = SystemInformation.PowerStatus.BatteryChargeStatus;
        if (status != BatteryChargeStatus.NoSystemBattery) {
            var batteryStatus = status == 0 ? "Not charging" : status.ToString();
            // etc...
        }
