        public static LotInformation ReadLotFromFile(string filePath)
        {
            LotInformation lot;
            using (var reader = new StreamReader(filePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(LotInformation), new XmlRootAttribute { ElementName = "lot_information", IsNullable = false });
                lot = (LotInformation)xmlSerializer.Deserialize(new StreamReader(filePath));
            }
            return lot;
        }
        public static void AddLotToDb(LotInformation lot)
        {
            using(var db = new DMIDataContext())
            {
                db.LotInformation.Add(lot);
                db.SaveChanges();
            }
        }
        public static void ExampleUsage()
        {
            AddLotToDb(ReadLotFromFile("my_lot.xml"));
        }
