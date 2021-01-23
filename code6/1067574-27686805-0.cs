            var query = deliveryMethods
                .OrderBy(x => x.Slots.Min(s => s.ExpectedDeliveryDate).Year)
                .ThenBy(x => x.Slots.Min(s => s.ExpectedDeliveryDate).Month)
                .ThenBy(x => x.Slots.Min(s => s.ExpectedDeliveryDate).Date)
                .ToList();
