    using Microsoft.SqlServer;
    using Microsoft.SqlServer.Management.Smo;
    using Microsoft.SqlServer.Management.Common;
    using System.Data.SqlClient;
    using System.Configuration;
    public void BackupDatabase(string BackUpLocation, string BackUpFileName, string      DatabaseName, string ServerName)
    {
        DatabaseName = "[" + DatabaseName + "]";
        string fileUNQ = DateTime.Now.Day.ToString() + "_" + DateTime.Now.Month.ToString() + "_" + DateTime.Now.Year.ToString() +"_"+ DateTime.Now.Hour.ToString()+ DateTime.Now .Minute .ToString () + "_" + DateTime .Now .Second .ToString () ;
        BackUpFileName = BackUpFileName + fileUNQ + ".bak";
        string SQLBackUp = @"BACKUP DATABASE " + DatabaseName + " TO DISK = '" + BackUpLocation + "\\" + BackUpFileName + @"'";
        string svr = "Server=" + ServerName + ";Database=" + DatabaseName + ";Integrated Security=True";
        SqlConnection cnBk = new SqlConnection(svr);
        SqlCommand cmdBkUp = new SqlCommand(SQLBackUp, cnBk);
        try
        {
            cnBk.Open();
            cmdBkUp.ExecuteNonQuery();
            //MessageBox.Show("Done");
            MessageBox.Show(SQLBackUp + " ######## Server name " + ServerName + " Database " + DatabaseName + " successfully backed up to " + BackUpLocation + "\\" + BackUpFileName + "\n\nBackUp Date : " + DateTime.Now.ToString());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            //MessageBox.Show(SQLBackUp + " ######## Server name " + ServerName + " Database " + DatabaseName + " successfully backed up to " + BackUpLocation + @"\" + BackUpFileName + "\n Back Up Date : " + DateTime.Now.ToString());
        }
        finally
        {
            if (cnBk.State == ConnectionState.Open)
            {
                cnBk .Close(); 
            }
        }
    }
