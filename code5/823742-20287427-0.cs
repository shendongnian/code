            foreach (var s in allShipments)
            {
                var svm = new ShipmentVM
                {
                    Shipment = s,
                    Containers = (new CollectionViewSource { Source = allContainerVMs }).View
                };
                svm.Containers.Filter = (o) => (o as ContainerVM).Container.ShipmentID == svm.Shipment.ShipmentID;
                allShipmentVMs.Add(svm);
            }
