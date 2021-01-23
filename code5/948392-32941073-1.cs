        public static byte[] SerializeKml(this KmlFile kml)
        {
            var serializer = new Serializer(); 
            serializer.Serialize(kml.Root); 
            var str = serializer.Xml;
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }
        public ActionResult GetKml()
        {
            Placemark placemark = new Placemark
            {
                Geometry = new Point { Coordinate = new Vector(-13.163959, -72.545992) },
                Name = "Machu Picchu",
            };
            var kml = KmlFile.Create(placemark, false);
            var fcResult = new FileContentResult(kml.SerializeKml(), "application/vnd.google-earth.kml+xml");
            return fcResult;
        }
