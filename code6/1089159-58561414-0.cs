        public static void AppendToCsv(ShopDataModel shopRecord)
        {
            using (var writer = new StreamWriter(DestinationFile, true))
            {
                using (var csv = new CsvWriter(writer))
                {
                    csv.WriteRecord(shopRecord);
                    writer.Write("\n");
                }
            }
        }
