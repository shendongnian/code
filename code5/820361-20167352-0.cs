    class TermSh
    {
        public HttpWebRequest request_get_page_with_captcha;
        public HttpWebResponse response_get_page_with_captcha;
        public string url;
        public int id = 0;
        public TermSh(Form1 form1)
        {
            this.form1 = form1;
        }
        public List<Log> somemethod()
        {
            try
            {                
                cookies += response_get_page_with_captcha.Headers["Set-Cookie"];
                List<Log> retList = new List<Log>();
                retList.Add(new Log(id++, DateTime.Now, cookies));
                return retList; //use this return value in your Form and update datagridview  
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
