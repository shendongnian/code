    public class WhatsAppSend
    {
        public WhatsAppBulk form1;
        public WhatsAppSend(WhatsAppBulk _form1)
        {
            form1 = _form1;
            count_sleep = Convert.ToInt32(form1.txtMsgGap.Text);
        }
        public String line = "";
        public String command = "";
        public string[] dst;
        public int count_sleep;
        public string WhatsAppType = "";
        public string DataToSend = "";
        public string ext = "";
        public void xyz(string nickname, string sender, string password, string[] Datadst, string DataWhatsAppType, string DataDataToSend, string Dataext)
        {
            dst = Datadst;
            WhatsAppType = DataWhatsAppType;
            DataToSend = DataDataToSend;
            ext = Dataext;
            WhatsApp wa = new WhatsApp(sender, password, nickname, true);
        }
    }
