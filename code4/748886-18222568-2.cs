        public String Na
        {
            get
            {
                return Buffer.GetString(BufferColumnIndexes[0]);
            }
        }
        public bool Na_IsNull
        {
            get
            {
                return IsNull(0);
            }
        }
