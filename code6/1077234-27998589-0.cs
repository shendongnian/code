    [Table("CURRENCY")]
        public class CurrencyClass : ICurrency
        {
            private Int32 mCURRENCY_ID = default(Int32);
            [Key]
            public virtual Int32 CURRENCY_ID  
            {
                get { return mCURRENCY_ID; }
                set { mCURRENCY_ID = value; }
            }
            private string mCURRENCY_NAME = default(string); 
            public virtual string CURRENCY_NAME 
            { 
                get { return mCURRENCY_NAME;}
                set { mCURRENCY_NAME = value;}
            }
            private string mCURRENCY_DESC = default(string);
            public  virtual string CURRENCY_DESC 
            {
                get { return mCURRENCY_DESC; }
                set { mCURRENCY_DESC = value; }
            }
            private string mCURRENCY_SYMBOLE = default(string);
            public virtual string CURRENCY_SYMBOLE 
            {
                get { return mCURRENCY_SYMBOLE; }
                set { mCURRENCY_SYMBOLE = value; }
            }
            private Int32 mcreated_by = default(Int32);
            public virtual Int32 created_by 
            {
                get { return mcreated_by; }
                set { mcreated_by = value; } 
            }
            private DateTime mcreated_date = default(DateTime);
            public virtual DateTime created_date 
            {
                get { return mcreated_date; }
                set { mcreated_date = value; } 
            }
            private Int32 mmodified_by = default(Int32);
            public virtual Int32 modified_by 
            {
                get { return mmodified_by; }
                set { mmodified_by = value; } 
            }
            private DateTime mmodified_date = default(DateTime);
            public virtual DateTime modified_date 
            {
                get { return mmodified_date; }
                set { mmodified_date = value; }
            }
        }
