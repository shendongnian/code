    using Newtonsoft.Json;
     [WebMethod]
        public static string allocatebr(string brlist)
        {
            
            List<Allocationbr> brs = JsonConvert.DeserializeObject<List<Allocationbr>>(brlist);
            foreach (Allocationbr b in brs)
            {
                x......
            }
            return x.ToString();
        }
