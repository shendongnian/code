    var e = c.Entities.Where(
                         x => x.Address.AddressType.AddressTypeID == 1
                           && x.Tags.Any(y => y.Feature.FeatureID == 39)
                        );
     foreach (var a in p)
            {
                var d = a.Tags.Where(y => y.Feature.FeatureID == 39).FirstOrDefault();
                if (d != null)
                {
                    e.Add(a);
                }
            }
