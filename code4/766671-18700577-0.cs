            using (SqlCommand cmd = new SqlCommand("select template from dbo.EnrollDigital where id=4", sqlConnection))
            {
                byte[] templateData = (byte[])cmd.ExecuteScalar();
                Image img = byteArrayToImage(templateData);
            }
