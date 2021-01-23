    class User
    {
        public string mName { get; private set; }
        public string mSurname { get; private set; }
        public int mPesel { get; private set; }
        public DateTime mBDate { get; private set; }
        public string mEmail { get; private set; }
    
        //constructor for User class
        public User(string mName2, string mSurname2, string mPesel2, string mBDate2, string mEmail2)
        {
                mName = mName2;
                mSurname = mSurname2;
                mPesel = Convert.ToInt32(mPesel2);
                mBDate = Convert.ToDateTime(mBDate2);
                mEmail = mEmail2;
        }
    }
