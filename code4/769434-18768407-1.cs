    var result = doc
        .Root
        .Elements()
        .Select(elem => new OrderAction
                (
                    (Action)Enum.Parse(typeof(Action), elem.Name.LocalName.ToUpper()),
                    new Order
                    (
                        elem.Attributes("order-id").Select(x => long.Parse(x.Value)).FirstOrDefault(),
                        elem.Attributes("symbol").Select(x => x.Value).FirstOrDefault(),
                        elem.Attributes("price").Select(x => int.Parse(x.Value)).FirstOrDefault(),
                        elem.Attributes("quantity").Select(x => int.Parse(x.Value)).FirstOrDefault()
                    )
                ));
