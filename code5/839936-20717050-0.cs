      private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerAsync();
        }
      private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoBulkCopy();
        }
      private void DoBulkCopy()
      {
         using (SqlConnection destinationConnection = Login.GetConnection())
         {
            destinationConnection.Open();
            using (SqlTransaction transaction = destinationConnection.BeginTransaction(IsolationLevel.ReadCommited))
            {
              using (SqlBulkCopy bulkCopy = new SqlBulkCopy(destinationConnection, SqlBulkCopyOptions.KeepIdentity, transaction))
               {
                 bulkCopy.DestinationTableName = "dbo." + tableName;                            
                 try
                 {
                   bulkCopy.WriteToServer(dt);
                   transaction.Commit();
                   bulkCopySuccess = true;
                 }
                 catch (Exception ex)
                 {
                  transaction.Rollback();
                  MessageBox.Show(ex.Message, ex.GetType().ToString());
                  bulkCopySuccess = false;
                 }
                }
             }
          }
    }
