    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Xml.Serialization;
    namespace Code.Without.IDE
    {
        //http://stackoverflow.com/questions/20697928/how-to-deserialize-xml-to-listobject
        public class Dummy
        {
            private static void Main()
            {
                List<RoomRateResult> ArrayOfRoomRateResult = new List<RoomRateResult>();
                RoomRateResult rs1 = new RoomRateResult
                                            {
                                                ErrorMessage = string.Empty,
                                                OperationSuccess = true,
                                                Allotment = 10,
                                                Breakfast = true,
                                                CheckInDate = DateTime.Now,
                                                CloseSelling = false,
                                                CommissionPct = 3.0d,
                                                CurrCode = "USD",
                                                FreeSell = true,
                                                RoomRateId = 100,
                                                RoomType = "Mega",
                                                SingleRate = 95d,
                                                TripleRate = 150d,
                                                TwinDoubleRate = 150d
                                            };
                                            
                RoomRateResult rs2 = new RoomRateResult
                                            {
                                                ErrorMessage = string.Empty,
                                                OperationSuccess = true,
                                                Allotment = 12,
                                                Breakfast = true,
                                                CheckInDate = DateTime.Now,
                                                CloseSelling = false,
                                                CommissionPct = 2.0d,
                                                CurrCode = "USD",
                                                FreeSell = true,
                                                RoomRateId = 110,
                                                RoomType = "Mega",
                                                SingleRate = 90d,
                                                TripleRate = 140d,
                                                TwinDoubleRate = 150d
                                            };
                
                ArrayOfRoomRateResult.Add(rs1);
                ArrayOfRoomRateResult.Add(rs2);
                
                XmlSerializer ser = new XmlSerializer(typeof(List<RoomRateResult>));
                TextWriter writer = new StreamWriter("serl.xml");
                ser.Serialize(writer, ArrayOfRoomRateResult);
                writer.Flush();
                writer.Close();
            }
        }
        
        [Serializable]
        public class RoomRateResult
        {
            public string ErrorMessage { get; set; }
            public bool OperationSuccess { get; set; }
            public int Allotment { get; set; }
            public bool Breakfast { get; set; }
            public DateTime CheckInDate { get; set; }
            public bool CloseSelling { get; set; }
            public double CommissionPct { get; set; }
            public string CurrCode { get; set; }
            public bool FreeSell { get; set; }
            public int RoomRateId { get; set; }
            public string RoomType { get; set; }
            public double SingleRate { get; set; }
            public double TripleRate { get; set; }
            public double TwinDoubleRate { get; set; }
        }
    }
