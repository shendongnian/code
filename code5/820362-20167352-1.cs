    class TermSh
    {
        public HttpWebRequest request_get_page_with_captcha;
        public HttpWebResponse response_get_page_with_captcha;
        public string url;
        public int id = 0;
        public List<Log> somemethod()
        {
            try
            {                
                cookies += response_get_page_with_captcha.Headers["Set-Cookie"];
                return new Log(id++, DateTime.Now, cookies); //use this return value in your Form and update datagridview 
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
