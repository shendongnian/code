    public class Boat
        {
            public Boat(string BoatName, string BoatType, string BoatOverAllLength)
            {
                this.BoatName = BoatName;
                this.BoatType = BoatType;
                this.BoatOverAllLength = BoatOverAllLength;
            }
            public string BoatName { get; set; }
            public string BoatType { get; set; }
            public string BoatOverAllLength { get; set; }
            public string BoatDets
            {
                get
                {
                    return this.BoatName + " [" + this.BoatType + ", " + this.BoatOverAllLength + "]";
                }
            }
        }
            var slipDets6 = (from s6 in db.Slips
                             join b6 in db.Boats on s6.BoatId equals b6.BoatId into temp
                             from jn in temp.DefaultIfEmpty()
                             orderby s6.SlipNumber
                             select new { s6, jn })
                             .ToList()
                             .Select(u => new
                             {
                                 SlipID = (int?)u.s6.SlipId,
                                 SlipNumber = u.s6.SlipNumber,
                                 Length = u.s6.Length,
                                 Electricity = u.s6.Electricity,
                                 Telephone = u.s6.Telephone,
                                 TV = u.s6.TV,
                                 BoatDets = new Boat(u.jn.BoatName, u.jn.BoatType, u.jn.BoatOverAllLength),
                                 Status = u.s6.Status
                             })
                             .ToList();
