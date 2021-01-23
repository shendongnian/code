    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
             //test data
             DataTable dt = new DataTable();
             dt.Columns.Add("LectureID", typeof(int));
             dt.Columns.Add("SubjectName");
             dt.Rows.Add(1, "Sub1");
             dt.Rows.Add(1, "Sub2");
             dt.Rows.Add(1, "Sub3");
             dt.Rows.Add(1, "Sub4");
             dt.Rows.Add(2, "Sub1");
             dt.Rows.Add(2, "Sub4");              
             dt.AcceptChanges();               
             //Bind with GridView with Dictionary collection
             GridView1.DataSource = GetDictionary(dt);
             GridView1.DataBind();
        }
    }
    //get a dictionary of distinct lectureID
    private Dictionary<int, List<string>> GetDictionary(DataTable dt)
        {
            var dictionary = new Dictionary<int, List<string>>();
            foreach (DataRow dr in dt.Rows)
            {
                int iKey = Convert.ToInt32(dr["LectureID"]);
                if (dictionary.ContainsKey(iKey))
                {
                    List<string> lst = dictionary[iKey] as List<string>;
                    lst.Add(dr["SubjectName"].ToString());
                    dictionary[iKey] = lst;
                }
                else
                {
                    var lst = new List<string>();
                    lst.Add(dr["SubjectName"].ToString());
                    dictionary.Add(iKey, lst);
                }
            }
            return dictionary;
        }
