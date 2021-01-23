    public string GetLocality()
        {
            string[] locality = new string[] { "Loc_A", "Loc_B", "Loc_C", "Loc_D", };
            //long[] frequency = new long[] { 10, 20, 10, 80 };
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string jsonobj = jsSerializer.Serialize(locality);
            return jsonobj;       
        }
