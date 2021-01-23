    var xyz = deliveryMethods
            .OrderBy(x => x.Slots.OrderBy(y => y.ExpectedDeliveryDate.Year))
            .ThenBy(x => x.Slots.OrderBy(y => y.ExpectedDeliveryDate.Month))
            .ThenBy(x => x.Slots.OrderBy(y => y.ExpectedDeliveryDate.Date))
            .ToList();
