        public static void Serialize(string filename, UtilityRateSummaries objToXMl)
        {
            var xs
                = new XmlSerializer(objToXMl.GetType());
            var writer = File.CreateText(filename);
            xs.Serialize(writer, objToXMl);
            writer.Flush();
            writer.Close();
        }
        public static UtilityRateSummaries Deserialize(string filename)
        {
            var xs
                = new XmlSerializer(
                    typeof(UtilityRateSummaries));
            var reader = File.OpenText(filename);
            var utilityRateSummaries = (UtilityRateSummaries)xs.Deserialize(reader);
            reader.Close();
            return utilityRateSummaries;
        }
       static void Main(string[] args)
        {
            var obj1 = new UtilityRateSummaries();
            obj1.Utility = new Utility();
            obj1.Utility.UtilityId = 81;
            obj1.Utility.UtilityName = "Pacific Gas and Electric Company (PG&E)";
            obj1.Rate = new Rate();
            obj1.Rate.Id = 238;
            obj1.Rate.Name = "Residential Service (Rate E1 Area Y Code B)";
            obj1.Rate.IsDefault = true;
            obj1.Rate.IsTimeOfUse = false;
            obj1.Rate.Metering = "OptionalNetMetering";
            obj1.Rate.Name = "1";
            obj1.Rate.Sector = "Residential";
            Serialize("bla.xml",obj1);
            var obj = Deserialize("bla.xml");
            Console.Out.WriteLine(obj.Rate.Id);
        }
