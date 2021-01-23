     public static Size GetOptimalScreenResolution()
        {
            var scope = new System.Management.ManagementScope();
            var query = new System.Management.ObjectQuery("SELECT * FROM CIM_VideoControllerResolution");
            UInt32 maxHResolution = 0;
            UInt32 maxVResolution = 0;
            UInt32 maxHForMaxVResolution = 0;
            using (var searcher = new System.Management.ManagementObjectSearcher(scope, query))
            {
                var results = searcher.Get();
                foreach (var item in results)
                {
                    if ((UInt32) item["HorizontalResolution"] >= maxHResolution)
                    {
                        maxHResolution = (UInt32) item["HorizontalResolution"];
                        if ((UInt32)item["VerticalResolution"] > maxVResolution || maxHForMaxVResolution != maxHResolution)
                        {
                            maxVResolution = (UInt32)item["VerticalResolution"];
                            maxHForMaxVResolution = (UInt32)item["HorizontalResolution"]; 
                        }
                    }
                } 
            }
            return new Size(maxHResolution, maxVResolution);
        }
