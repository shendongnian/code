            var xDocument = XDocument.Load(FileName);
            var pidNodes = xDocument.Descendants("PID");
            var pids = pidNodes.Select(x => new
            {
                OffsetX = x.Attribute("OffsetX").Value,
                OffsetY = x.Attribute("OffsetY").Value,
                TRef = x.Attribute("TRef").Value
            });
            var objectNodes = xDocument.Descendants("Object");
            var objects = objectNodes.Select(x => new
            {
                OID = x.Attribute("OID").Value,
                ObjectName = x.Attribute("ObjectName").Value,
                ObjectType = x.Attribute("ObjectType").Value
            });
            var result = pids.Select(x => new
            {
                OffsetX = x.OffsetX,
                OffsetY = x.OffsetY,
                ObjectName = objects.Single(o => o.OID == x.TRef).ObjectName
            });
