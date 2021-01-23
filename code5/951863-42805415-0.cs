        public void Log(string msg)
        {
            if (msg == null)
                throw new ArgumentNullException("msg");
            using (Record record = new Record(0))
            {
                record.FormatString = msg;
                int num = (int) this.Message(InstallMessage.Info, record);
            }
        }
