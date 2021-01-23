    public void dataPullingThread(){
        try{
            //your connection code goes here like below//
            environments = ConfigurationManager.GetSection("Environment") as NameValueCollection;
            string strConnString = environments[envs];
            conn = new OleDbConnection(strConnString);
            conn.Open();
            OleDbDataAdapter objDa = new OleDbDataAdapter("select * from tblABC", conn);
            DataSet ds1 = new DataSet();
            objDa.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
            conn.Close();
        }
        catch (Exception e){
    
        }
    }
    //call your thread from desired location in program///
    using System.Threading;
    Thread thread = new Thread (new ThreadStart(dataPullingThread));
    thread.start;
    //Your application will continuously run; however, the data will appear when ever the thread auto kills itself. You can boost the speed if you create more then one thread. That means each thread selecting different rows of the database, I hope this information will help you//
