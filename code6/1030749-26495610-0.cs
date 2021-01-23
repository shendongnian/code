    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    namespace Server.Controllers
    {
        public class TempController : ApiController
        {
            public StationCoordinates GetExtAllStations()
            {
                RCWindsWCFService.Service1Client client = new RCWindsWCFService.Service1Client();
                StationCoordinates coordinates = new StationCoordinates();
                IEnumerable<RCWindsWCFService.uspGetAllStationsResult> results = client.GetExtAllStations();
                coordinates.Station_Coordinates = results;
                return coordinates;
            }
    
            public class StationCoordinates
            {
                public IEnumerable<RCWindsWCFService.uspGetAllStationsResult> Station_Coordinates { set; get; }
            }
    
        }
    }
    
    namespace RCWindsWCFService
    {
        public class uspGetAllStationsResult
        {
            public double POINT_X { get; set; }
            public double POINT_Y { get; set; }
            public string TABLE_NAME { get; set; }
        }
    
        public class Service1Client
        {
            public IEnumerable<uspGetAllStationsResult> GetExtAllStations()
            {
                return new List<uspGetAllStationsResult>()
                {
                    new uspGetAllStationsResult() {POINT_X= -81.0410610591,POINT_Y= 34.1831858023,TABLE_NAME= "Cedar Creek"},
                    new uspGetAllStationsResult() {POINT_X= -80.7653777161,POINT_Y= 33.8641198907,TABLE_NAME= "Gadsden"}
                };
            }
        }
    }
