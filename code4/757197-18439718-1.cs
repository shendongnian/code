        protected void chkStudentStatus_CheckedChanged(object sender, EventArgs e)
        {
            Entity.Permission objPermission=new Entity.Permission();
            SessionManager.GetUserPermission.Add(objPermission);
            SessionManager.GetUserPermission.RemoveAt(0);
            
        }
