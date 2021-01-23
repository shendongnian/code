    class Scalar {
        public int Col { get; set; }
    }
    SQLiteAsyncConnection conn;
    List<Scalar> result;
    result = await conn.QueryAsync<Scalar>("SELECT Col FROM Table");
