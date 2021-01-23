     using System.Web.Script.Serialization;
     using Newtonsoft.Json;
     namespace TestApp.components.seatfromdb
    {
    public class Test
    {
        public string name { get; set; }
        public string value { get; set; }
    }
    public partial class seatfromdb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {     
     }
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            List<Test> myDeserializedObjList = (List<Test>)Newtonsoft.Json.JsonConvert.DeserializeObject(hdnSelectedTicket.Value, typeof(List<Test>));
            int count = myDeserializedObjList.Count;
            string[] chkarr = new string[count-4];
            int j=0;
            for (int i = 0; i < count; i++)
            {
                if (myDeserializedObjList[i].name.Substring(0, 6) == "check_")
                {
                    chkarr[j] = myDeserializedObjList[i].name.Substring(6,1);
                    j++;
                }
            }
        }
    }
