            protected void Page_Load(object sender, EventArgs e)
            {
                try
                {
                    if (string.IsNullOrEmpty(Request.QueryString["AdHoc"]) == false)
                    {
        
         
        
                           string v_AdHocParam = Request.QueryString["AdHoc"];
                            string [] v_ListParam = v_AdHocParam.Split(new char[] {','});
            
                            if (v_ListParam.Length < 2)
            {
     
    
                       DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(WS_DemandeIntervention));
                        WS_DemandeIntervention response = (WS_DemandeIntervention)jsonSerializer.ReadObject(Request.InputStream);
    ....
    }
     
    
       if (string.IsNullOrEmpty(Request.QueryString["IdBonDeCommande"])==false)
    
                        {
        ....
