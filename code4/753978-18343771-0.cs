                string ServiceTag = "your service tag here";
                DellServiceReference.AssetServiceSoapClient svc = new DellServiceReference.AssetServiceSoapClient();
                Guid DellFeeder = new Guid("12345678-1234-1234-1234-123456789012");
                DellServiceReference.Asset[] assets = svc.GetAssetInformation(DellFeeder, "dellwarrantycheck", ServiceTag);
                // go through each warranty
                DellServiceReference.EntitlementData[] entitlements = assets[0].Entitlements;
                foreach (DellServiceReference.EntitlementData warr in entitlements)
                {
                    DateTime start = warr.StartDate;
                    DateTime stop = warr.EndDate;
                    // do stuff with this
                }
