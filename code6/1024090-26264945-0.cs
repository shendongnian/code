        private String getPlatypusFileName(String billNum)
        {
            const string basePortion = "Platypus_";
            String PlatypusFileName;
            DateTime dt = DateTime.Now;
            PlatypusFileName = String.Format("{0}{1}_{2}.xml",
                basePortion, billNum.PadLeft(6,'0'), dt.ToString("yyyyMMddHHmmss_fff"));
            return PlatypusFileName;
        }
