    DbParameter p1 = Database.AddParameter("@p1", (object)band.Name ?? DBNull.Value);
    DbParameter p2 = Database.AddParameter("@p2", (object)band.Picture ?? DBNull.Value);
    DbParameter p3 = Database.AddParameter("@p3", (object)band.Description ?? DBNull.Value);
    DbParameter p4 = Database.AddParameter("@p4", (object)band.Facebook ?? DBNull.Value);
    DbParameter p5 = Database.AddParameter("@p5", (object)band.Twitter ?? DBNull.Value);
