            get; set;
        }
        public string age
        {
            get;
            set;
        }
        public string id
        {
            get;
            set;
        }
        public string marks
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
    
    public List<info> getdata()
    {
        string c =
                "Data Source=bla ;bla ;bla";
        SqlConnection con = new SqlConnection(c);
        DataSet ds = SqlHelper.ExecuteDataset(con, CommandType.Text, "SELECT * from table1");
        var list = (ds.Tables[0].AsEnumerable().Select(
            df =>
            new info
            {
                age = df[0].ToString(),
                counter = df[1].ToString(),
                id = df[3].ToString(),
                name = df[4].ToString(),
                marks = df[2].ToString()
            })).ToList();
        return list;
    }
    }
    class Program
    {
        static void Main(string[] args)
        {
            info a =new info();
          List<info> list1= a.getdata();
            foreach (var info in list1)
            {
                Console.WriteLine(info.name+" "+info.age+" "+info.marks);
            }
            
           Console.Read();
        }
    }
