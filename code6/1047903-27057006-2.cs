     using Newtonsoft.Json;
    protected void btn_submit_Click(object sender, EventArgs e)
        {
            //string a = hdnSelectedTicket.Value;
            List<Test> myDeserializedObjList = (List<Test>)Newtonsoft.Json.JsonConvert.DeserializeObject    (hdnSelectedTicket.Value, typeof(List<Test>));
        }
