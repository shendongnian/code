            string[] parts = "2013-03-31,1299,2013-03-31,1099,9888, 0".Split(',');
            sqlCom.Parameters.Add("@AddedDateTime", SqlDbType.VarChar).Value = parts[0].ToString();
            sqlCom.Parameters.Add("@IMEI", SqlDbType.VarChar).Value = parts[1].ToString();
            sqlCom.Parameters.Add("@RecordedDateTime", SqlDbType.VarChar).Value = Convert.ToDateTime(parts[2].ToString());
            sqlCom.Parameters.Add("@Latitude", SqlDbType.VarChar).Value = parts[3].ToString(); ;
            sqlCom.Parameters.Add("@Longitude", SqlDbType.VarChar).Value = parts[4].ToString(); ;
            sqlCom.Parameters.Add("@IsParking ", SqlDbType.Bit).Value = ((parts[5].ToString().Trim()).Equals("0"))? true: false;
