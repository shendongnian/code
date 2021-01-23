    secondObjectList.AsParallel().ForAll(s =>
        {
            FirstObject obj = new FirstObject
            {
                Name = item.Name,
                DecimalProp = Convert.ToDecimal(item.StringProp)
            };
            firstObjectList.Add(obj);
        });
