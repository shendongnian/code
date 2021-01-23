    [WebMethod]
    public static string GETCUST(string RefNo) {
        try {
            DataTable dtOutput = new DataTable();
            dtOutput = Generix.getData("dbo.customers", "[first_name],[middle_name]", "reference_no='" + RefNo + "'", "", "", 1);
            if (dtOutput.Rows.Count > 0) {
                return dtOutput.Rows[0][0].ToString() + "|" + dtOutput.Rows[0][1].ToString();
            }
        } catch (Exception xObj) {
            return "ERROR: " + xObj.Message;
        }
    }
