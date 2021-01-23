    var result = doc
        .Root
        .Elements()
        .Select(elem =>
            {
                switch (elem.Name.LocalName)
                {
                    case "add":
                        return new OrderAction
                        (
                            Action.ADD,
                            new Order
                            (
                                long.Parse(elem.Attribute("order-id").Value),
                                elem.Attribute("symbol").Value,
                                int.Parse(elem.Attribute("price").Value),
                                int.Parse(elem.Attribute("quantity").Value)
                            )
                        );
                    case "remove":
                        return new OrderAction
                        (
                            Action.REMOVE,
                            new Order
                            (
                                long.Parse(elem.Attribute("order-id").Value),
                                null,
                                -1,
                                -1
                            )
                        );
                    case "edit":
                        return new OrderAction
                        (
                            Action.EDIT,
                            new Order
                            (
                                long.Parse(elem.Attribute("order-id").Value),
                                null,
                                int.Parse(elem.Attribute("price").Value),
                                int.Parse(elem.Attribute("quantity").Value)
                            )
                        );
                    default:
                        return null;
                }
            });
