    namespace charting
    {
    class fbvm : ViewModelBase, INotifyPropertyChanged
    {
        OleDbConnection ConDb;
        public String eID;
        public string _Indexname;
        public string Indexname
        {
            get
            {
                return _Indexname;
            }
            set
            {
                _Indexname = value;
               
                LoadColumnChartData(Indexname);
                OnPropertyChanged(() => Indexname);
            }
        }
        private List<KeyValuePair<string, float>> _chartData;
        public List<KeyValuePair<string, float>> ChartData
        {
            get
            {
                return _chartData;
            }
            set
            {
                _chartData = value;
                OnPropertyChanged(() => ChartData);
            }
        }
        private List<string> _MyComboBoxData;
        public List<string> MyComboBoxData
        {
            get
            {
                return _MyComboBoxData;
            }
            set
            {
                _MyComboBoxData = value;
                OnPropertyChanged(() => MyComboBoxData);
            }
        }
        
       
        public fbvm()
        {
            MyComboBoxData = new List<string>();
            comboboxload();
        }
         private void comboboxload()
         {
            ConDb = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\\\\CORE-2\\Jeevanawashyak\\Feedback.accdb");
            try
            {
                     ConDb.Open();
                     OleDbCommand DBSelect = new System.Data.OleDb.OleDbCommand("select FName, LName,ID_NAME from NameList", ConDb);
                     OleDbDataReader reader = DBSelect.ExecuteReader();
                     while (reader.Read())
                     {
                         string eNAME = "";
                         eID = reader["ID_NAME"].ToString();
                         eNAME += reader["FName"].ToString();
                         eNAME += " " + reader["LName"].ToString();
                         MyComboBoxData.Add(eNAME);
                     }
                 }
                 catch (Exception ae)
                 {
                     MessageBox.Show(ae.Message);
                 }//catch
         }
        private void LoadColumnChartData(string Ind)
        {
            ChartData = new List<KeyValuePair<string, float>>();
            int count2 = 0;
            string temp = Ind;
            string temptodb = null;
            foreach (var part in temp.Split(' '))
            {
                temptodb += part.Substring(0, 1);
                if(count2<1)
                temptodb += "_";
                count2++;
            }
            int cc1=0,tc1=0,aa1=0,blfe1=0,count=0;
            float cc11 = 0, tc11 = 0, aa11 = 0, blfe11 = 0;
            string query = "select CC,TC,AA,BLFE,WMU from "+temptodb;
                OleDbCommand select = new OleDbCommand("select", ConDb);
                select.CommandText = query;
                OleDbDataReader reader = select.ExecuteReader();
                while (reader.Read())
                {
                    cc1 += Int32.Parse(reader[0].ToString());
                    tc1 += Int32.Parse(reader[1].ToString());
                    aa1 += Int32.Parse(reader[2].ToString());
                    blfe1 += Int32.Parse(reader[3].ToString());
                    ++count;
                }
                cc11 = (float)cc1 / count;aa11 = (float)aa1 / count;
                tc11 = (float)tc1 / count; blfe11 = (float)blfe1 / count;
                //   cc11 = 3.11f;
                //  MessageBox.Show(cc11.ToString(), tc11.ToString());
                ChartData.Add(new KeyValuePair<string, float>("Communication", cc11));
                ChartData.Add(new KeyValuePair<string, float>("Topic Coverage", tc11));
                ChartData.Add(new KeyValuePair<string, float>("Audience Attn.", aa11));
                ChartData.Add(new KeyValuePair<string, float>("Body Language & Facial Expr.", blfe11));
                ChartData = new List<KeyValuePair<string, float>>(ChartData);
            
        }//loadcoloumnchart
        
    
    }//class fbvm
