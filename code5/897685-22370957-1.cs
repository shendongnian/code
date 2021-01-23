    public class FlatSlip
        {
            public int? SlipID { get; set; }
            public string SlipNumber { get; set; }
            public string Length { get; set; }
            public string Electricity { get; set; }
            public string Telephone { get; set; }
            public string TV { get; set; }
            public string BoatName { get; set; }
            public string BoatType { get; set; }
            public string BoatOverAllLength { get; set; }
            public string Status { get; set; }
            public string BoatDets
            {
                get
                {
                    return this.BoatName + " [" + this.BoatType + ", " + this.BoatOverAllLength + "]";
                }
            }
        }
    var slipDets6 = from s6 in db.Slips
                            join b6 in db.Boats on s6.BoatId equals b6.BoatId into temp
                            from jn in temp.DefaultIfEmpty()
                            orderby s6.SlipNumber
                            select new FlatSlip()
                            {
                                SlipID = (int?)s6.SlipId,
                                SlipNumber = s6.SlipNumber,
                                Length = s6.Length,
                                Electricity = s6.Electricity,
                                Telephone = s6.Telephone,
                                TV = s6.TV,
                                BoatName =jn.BoatName,
                                BoatType = jn.BoatType,
                                BoatOverAllLength = jn.BoatOverAllLength,
                                Status = s6.Status
                            };
