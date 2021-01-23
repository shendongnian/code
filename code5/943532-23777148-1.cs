    public class Person
    {
        #region Members
        private int _ID = -1;
        private string _FirstName = string.Empty;
        private string _LastName = string.Empty;
        private DateTime? _BirthDate = null;
        private string _PhoneNumber = string.Empty;
        private string _Email = string.Empty;
        private bool _Changed = false;
        #endregion
        public Person()
        {
            _Changed = false;
        }
        #region Methods
        public void Save()
        {
            if (!_Changed)
                return;
            using (SqlConnection con = new SqlConnection(@"server=.\sqlexpress;database=People;integrated Security=True;"))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Person_Save";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", _ID);
                cmd.Parameters.AddWithValue("@FirstName", _FirstName);
                cmd.Parameters.AddWithValue("@LastName", _LastName);
                cmd.Parameters.AddWithValue("@BirthDate", _BirthDate);
                cmd.Parameters.AddWithValue("@PhoneNumber", _PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", _Email);
                try
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            _ID = dr.GetInt32(0);
                            _Changed = false;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error message");
                }
            }
        }
        public void Delete()
        {
            using (SqlConnection con = new SqlConnection(@"server=.\sqlexpress;database=People;integrated Security=True;"))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "Person_Delete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", _ID);
                try
                {
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error message");
                }
            }
        }
        #endregion
        #region Properties
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    _Changed = true;
                }
            }
        }
        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (_FirstName != value)
                {
                    _FirstName = value;
                    _Changed = true;
                }
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (_LastName != value)
                {
                    _LastName = value;
                    _Changed = true;
                }
            }
        }
        public DateTime? BirthDate
        {
            get { return _BirthDate; }
            set
            {
                if (_BirthDate != value)
                {
                    _BirthDate = value;
                    _Changed = true;
                }
            }
        }
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set
            {
                if (_PhoneNumber != value)
                {
                    _PhoneNumber = value;
                    _Changed = true;
                }
            }
        }
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email != value)
                {
                    _Email = value;
                    _Changed = true;
                }
            }
        }
        public bool Changed
        {
            get { return _Changed; }
            set { _Changed = value; }
        }
        #endregion
    }
