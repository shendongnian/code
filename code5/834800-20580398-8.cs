    private void btnRestore_Click(object sender, EventArgs e)
    {
        // If there was a SQL connection created
        try
        {
            if (srvSql != null)
            {
                saveBackupDialog.Title = "Restore Backup File";
                saveBackupDialog.InitialDirectory = "D:";
                // If the user has chosen the file from which he wants the database to be restored
                if (openFD.ShowDialog() == DialogResult.OK)
                {
                    Thread oThread = new Thread(new ThreadStart(frmWaitShow));
                    oThread.Start();   
                    // Create a new database restore operation
                    Restore rstDatabase = new Restore();
                    // Set the restore type to a database restore
                    rstDatabase.Action = RestoreActionType.Database;
                    // Set the database that we want to perform the restore on
                    rstDatabase.Database = cmbDatabase.SelectedItem.ToString();
                    // Set the backup device from which we want to restore, to a file
                    BackupDeviceItem bkpDevice = new BackupDeviceItem(openFD.FileName, DeviceType.File);
                    // Add the backup device to the restore type
                    rstDatabase.Devices.Add(bkpDevice);
                    // If the database already exists, replace it
                    rstDatabase.ReplaceDatabase = true;
                    // Kill all processes
                    srvSql.KillAllProcesses(rstDatabase.Database);
                    // Set single-user mode
                    Database db = srvSql.Databases[rstDatabase.Database];
                    db.DatabaseOptions.UserAccess = DatabaseUserAccess.Single;
                    db.Alter(TerminationClause.RollbackTransactionsImmediately);
                    
                    // Detach database
                    srvSql.DetachDatabase(rstDatabase.Database, false);
                    // Perform the restore
                    rstDatabase.SqlRestore(srvSql);
                    oThread.Suspend();
                    MessageBox.Show("DataBase Restore Successfull"); 
                }
                else
                {
                    // There was no connection established; probably the Connect button was not clicked
                    MessageBox.Show("A connection to a SQL server was not established.", "Not Connected to Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
