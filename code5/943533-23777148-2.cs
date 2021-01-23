    public partial class PeopleForm : Form
    {
        public PeopleForm()
        {
            InitializeComponent();
            FillDataSource();
        }
        public void FillDataSource()
        {
            List<Person> list = new List<Person>();
            using (SqlConnection con = new SqlConnection(@"server=.\sqlexpress;database=People;integrated Security=True;"))
            {
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "People_Read";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                try
                {
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Person()
                            {
                                ID = (int)dr["ID"]
                               ,FirstName = dr["FirstName"] as string
                               ,LastName = dr["LastName"] as string
                               ,BirthDate = dr["BirthDate"] as DateTime?
                               ,PhoneNumber = dr["PhoneNumber"] as string
                               ,Email = dr["Email"] as string
                            });
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error message");
                }
            }
            personBindingSource.DataSource = list;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach (Person person in personBindingSource)
            {
                person.Save();
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            ((Person)grdPeople.CurrentRow.DataBoundItem).Delete();
            personBindingSource.RemoveAt(grdPeople.CurrentRow.Index);
        }
    }
