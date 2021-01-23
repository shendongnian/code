        private static GeoResponse CallGeoWS(string address)
        {
            string url = string.Format(
                    "http://maps.google.com/maps/api/geocode/json?address={0}&region=dk&sensor=false",
                    HttpUtility.UrlEncode(address)
                    );
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(GeoResponse));
            var res = (GeoResponse)serializer.ReadObject(request.GetResponse().GetResponseStream());
            latFound = res.Results[0].Geometry.Location.Lat;
            lngFound = res.Results[0].Geometry.Location.Lng;
            ////Show the geocoded result in Google Maps using your default browser
            //System.Diagnostics.Process.Start(string.Format("http://maps.google.com/maps?q={0}", address));
            return res;
        }
