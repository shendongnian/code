    using System.Net;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    using System.Web;
    
    public class GoogleMapsDll
    {
        public class GoogleMaps
        {
            /// <summary>
            ///
            /// </summary>
            /// <param name="address"></param>
            /// <returns></returns>
            public static GeoResponse GetGeoCodedResults(string address)
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
                return res;
            }
        }
    
        [DataContract]
        public class GeoResponse
        {
            [DataMember(Name = "status")]
            public string Status { get; set; }
    
            [DataMember(Name = "results")]
            public CResult[] Results { get; set; }
    
            [DataContract]
            public class CResult
            {
                [DataMember(Name = "geometry")]
                public CGeometry Geometry { get; set; }
    
                [DataContract]
                public class CGeometry
                {
                    [DataMember(Name = "location")]
                    public CLocation Location { get; set; }
    
                    [DataContract]
                    public class CLocation
                    {
                        [DataMember(Name = "lat")]
                        public double Lat { get; set; }
    
                        [DataMember(Name = "lng")]
                        public double Lng { get; set; }
                    }
                }
            }
    
            public GeoResponse()
            { }
        }
    }
