        public class PriserMdrEpayIdDto
        {
            public PriserMdrEpayIdDto(string priser, string mdr, string epayId)
            {
                Priser = priser;
                Mdr = mdr;
                EpayId = EpayId;
            }
    
            public string Priser { get; set; }
            public string Mdr { get; set; }
            public string EpayId { get; set; }
    
        }
    
    public PriserMdrEpayIdDto HentEpayIdFraPriser(int prisId)
    {
        SqlConnection conn1 = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        SqlCommand cmd1 = conn1.CreateCommand();
        cmd1.Connection = conn1;
        cmd1.CommandText = @"SELECT priser, epayId, mdr from Priser WHERE id = @id";
        cmd1.Parameters.AddWithValue("@id", prisId);
        conn1.Open();
        SqlDataReader readerBrugerA = cmd1.ExecuteReader();
        var epayId = "0";
        var priser = "0";
        var mdr = "0";
        if (readerBrugerA.Read())
        {
    
            priser = readerBrugerA["priser"].ToString();
            mdr = readerBrugerA["mdr"].ToString();
            epayId = readerBrugerA["epayId"].ToString();
            var result = new PriserMdrEpayIdDto(priser, mdr, epayId);
            conn1.Close(); 
            return result;
        }
       return null;
    }
