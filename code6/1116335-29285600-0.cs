    catch (SqlException ex)
        {
            if (ex.Number == 2627)
            {
                if (ex.Message.Contains("UNIQUE"))
                    //error msg regarding Unique key violation.
                else
                    //error msg regarding Primary key violation.
            }
            else
                    //any other error msg.
    }
