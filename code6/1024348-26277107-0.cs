     class CLS_ADD_ROOM
        {
            public void ADD_ROOM(string NAME_ROOM,int SIZE,int LAB)// <=== Change bool to int 
       {
                DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
                DAL.Open();
                SqlParameter[] param = new SqlParameter[3];
    
                param[0] = new SqlParameter("@NAME_ROOM", SqlDbType.VarChar, 50);
                param[0].Value = NAME_ROOM;
    
                param[1] = new SqlParameter("@SIZE", SqlDbType.Int);
                param[1].Value = SIZE;
    
                param[2] = new SqlParameter("@LAB", SqlDbType.Bit); //<=== keep it .bit
                param[2].Value = LAB ;
    
                
                DAL.ExecuteCommand("ADD_ROOM", param);
                DAL.Close();
                }
