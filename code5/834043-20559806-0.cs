            _serviceStatus.MissingItems.Add(Utility.GetXmlElementORAttributeName(type, property));
            return false;
        }
        if (passengers.Any(passengerInfo => (passengerInfo == null) || (passengerInfo != null && passengerInfo.Quantity == 0)))
        {
            _serviceStatus.InvalidItems.Add(Utility.GetXmlElementORAttributeName(type, property));
            return false;
        }
