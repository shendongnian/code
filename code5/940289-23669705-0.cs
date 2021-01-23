          status.MobNo = Convert.ToString(dsstatuses.Tables[0].Rows[i]["MobNo"]);
          status.PhoneNo = Convert.ToString(dsstatuses.Tables[0].Rows[i]["PhoneNo"]);
          status.IsActive = Convert.ToBoolean(dsstatuses.Tables[0].Rows[i]["IsActive"]);
          Branchmaster.Add(status);
       }
       return Branchmaster;
    }
