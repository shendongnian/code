    public static List<EmpData> GetData(int carrierId) {
        // code here..
        cmd.Parameters.AddWithValue("CarrierID", carrierId);
        // code here..
    }
