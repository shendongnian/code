    protected void rtrFile()
        {
            string newvar = "";
            string url = "http://vinipost.com/Services/Mobile_Application/wcfService.svc/getGroup?usrId=100";
            using (StreamReader streamReader = new StreamReader(WebRequest.Create(url).GetResponse().GetResponseStream()))
            newvar = streamReader.ReadToEnd();
    
        
            vpData fbdata = new JavaScriptSerializer().Deserialize<vpData>(newvar);
    
            GridView1.DataSource = fbdata.getGroupResult;
            GridView1.DataBind();
        }
        public class vpData
        {     
            public List<vpkUser> getGroupResult { get; set; }
        }
    
        public class vpkUser
        {
            public string code { get; set; }
            public string name { get; set; }
        }
        protected void Button4_Click(object sender, EventArgs e)
        {
            rtrFile();
        }
