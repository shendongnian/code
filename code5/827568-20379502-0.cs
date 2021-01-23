        DataSet u;
        DataTable generalAlertData = GetTable();
        u = generalAlertData.DataSet;
        u.Tables.Remove(generalAlertData.TableName);
        AlertSet.Tables.Add(generalAlertData);
