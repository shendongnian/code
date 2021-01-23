            string connectionid = GetConnectionid();
            try
            {
                User user = users.Find(u => u.connectionid == connectionid);
            }
            catch (Exception)
            {
                 // not found
            }
