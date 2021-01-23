        {
            string stateName = cmbState.SelectedItem.ToString();
            DataTable dt3 = DBHandling.GetcityDataTable(stateName);
            cmbCity.Items.Clear();
            if (dt3 != null && dt3.Rows.Count > 0)
            {
                foreach (DataRow dr in dt3.Rows)
                {
                    cmbCity.Items.Add(dr["CityName"].ToString());
                }
            }
        }
