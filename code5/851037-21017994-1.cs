    var xml = new XDocument(
            new XElement("SomeRoot",
                    output.Select(e => new XElement("Member",
                            new XElement("Num", e.Key),
                            new XElement("Name", e.First().Name),
                            e.Select(x => new XElement("Benefit",
                                new XElement("Bc", x.BenefitCode),
                                new XElement("Dt", x.EffectiveDate)))
                        ))
                )
        );
