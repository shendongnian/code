      public Dbclass(string Constring)
        {
            this.ConStr = Constring;
            DBcon = new SqlConnection(this.ConStr);
        }
