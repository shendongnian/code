    foreach (Microsoft.AnalysisServices.Role CubeDbRole in db.Roles)
    {
    string Rolename = CubeDbRole.Name;
    MessageBox.Show(Rolename);
    CubeDbRole.Members.Clear();
    CubeDbRole.Update();
    foreach (Microsoft.AnalysisServices.RoleMember CubeRoleMember in CubeDbRole.Members)
    {
    //In case you want to display members
     MessageBox.Show(CubeRoleMember);
        } 
    } 
