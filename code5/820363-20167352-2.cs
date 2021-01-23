    class Log
    {
        private int id;
        private DateTime datetime;
        private string log_text;
        public Log(int id, DateTime datetime, string log_text)
        {
            this.id = id;
            this.datetime = datetime;
            this.log_text = log_text;
        }
        #region properties
        public int ID { get { return id; } set { id = value; } }
        public DateTime DATE_TIME { get { return datetime; } set { datetime = value; } }
        public string LOG_TEXT { get { return log_text; } set { log_text = value; } }
        #endregion
    }
