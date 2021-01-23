    DataRow newRow = Manager.achievementsMine.NewRow();
    newRow.SetField<int>("CT_Q", count);
    newRow.SetField<DateTime>("CMPL_D", DateTime.Now);
    newRow.SetField<string>("USER_LAN_I", Manager.userID);
    newRow.SetField<string>("ACHV_I", ACHV_I);
    Manager.achievementsMine.Rows.Add(newRow);
