        public Service SelectByID(int ServiceID) 
        {
            string query = "select * from tblService where ServiceID=@ServiceID ";
            List<SqlParameter> lstParams = new List<SqlParameter>();
            lstParams.Add(new SqlParameter("@ServiceID", ServiceID));
            DataTable dt = DBUtility.SelectData(query, lstParams);
            Service serviceObj = new Service();
            if (dt.Rows.Count > 0)
            {
                serviceObj.ID = dt.Rows[0]["ID"].ToString();
                
                // Or you can use
                // serviceObj.ID = ServiceID;
                serviceObj.Name = dt.Rows[0]["Name"].ToString();
                serviceObj.Description = dt.Rows[0]["Description"].ToString();
                serviceObj.Photo = dt.Rows[0]["Photo"].ToString();
            }
            return serviceObj;
        }
