    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using Library.DataBase.dsLibraryTableAdapters;
    using Library.DataBase;    
    tbUsersTableAdapter tableAdapterUsers = new tbUsersTableAdapter();
    dsLibrary.tbUsersDataTable dataTableUsers;
    private void btnConfirm_Click_1(object sender, RoutedEventArgs e)
    {
         dataTableUsers = tableAdapterUsers.getDataByUserName(lblUser.Content.ToString());
         tbUsersRow = (dsLibrary.tbUsersRow)dataTableUsers.Rows[0];
         tbUsersRow.userPassword = txtNewPassword.Password.ToString();
         tableAdapterUsers.Update(dataTableUsers);
    }
