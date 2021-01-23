    [WebMethod]
        public static List<int> getAdd_Zip(int ZIP_ID)
        {
            try
            {
                BusinessContacts objContacts = new BusinessContacts();
                DataTable dtInf = objContacts.getAdd_Zip(ZIP_ID);
                List<int> lRes = new List<int>();
                if (dtInf.Rows.Count > 0)
                {
                    lRes.Add(Convert.ToInt32(dtInf.Rows[0]["COU_ID"]));
                    lRes.Add(Convert.ToInt32(dtInf.Rows[0]["STE_ID"]));
                    lRes.Add(Convert.ToInt32(dtInf.Rows[0]["MUN_ID"]));
                }
                return lRes;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
