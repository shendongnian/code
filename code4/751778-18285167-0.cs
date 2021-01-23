    public static Photo Load(int pPhotoId)
    {
        using (SqlConnection conn = new SqlConnection(Settings.Conn))
        {
            conn.Open();
            return conn.Get<Photo>(pPhotoId);
        }
    }
