       class Program
       {
          static DataTable myTable = GetTable();
          static ManualResetEvent waitHandle = new ManualResetEvent(false);
    
          static void Main(string[] args)
          {
             const int threadCount = 10;
             List<Thread> threads = new List<System.Threading.Thread>();
             for (int i = 0; i < threadCount; ++i) 
             {
                threads.Add(new Thread(new ParameterizedThreadStart(AddRowThread)));
                threads[i].Start(i);
             }
             waitHandle.Set(); // Release all the threads at once
             for (int i = 0; i < threadCount; ++i) 
             {
                threads[i].Join();
             }
             // Print results once threads return
             for (int i = 0; i < myTable.Rows.Count; ++i)
             {
                Console.WriteLine(myTable.Rows[i].Field<int>(0));
             }
             Console.WriteLine("---Processing Complete---");
             Console.ReadKey();
          }
    
          static void AddRowThread(object value)
          {
             waitHandle.WaitOne();
             DataRow myRow = myTable.NewRow(); // THIS RESULTS IN INTERMITTENT ERRORS
             lock (myTable)
             {
                //DataRow myRow = myTable.NewRow(); // MOVE NewRow() CALL HERE TO RESOLVE ISSUE
                myRow.SetField<int>("c1", (int)value);
                myTable.Rows.Add(myRow);
             }
          }
    
          static DataTable GetTable()
          {
             // Here we create a DataTable with four columns.
             DataTable table = new DataTable();
             table.Columns.Add("c1", typeof(int));       
             return table;
          }
       }
