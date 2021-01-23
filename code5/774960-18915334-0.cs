    DataTable dTable = new DataTable();
    string[] rolesarr = Roles.GetAllRoles();
    // add column for user name 
    dTable.Columns.Add("User Name", typeof(string));
    // then add all the roles as columns 
    Array.ForEach(rolesarr, r => dTable.Columns.Add(r));
