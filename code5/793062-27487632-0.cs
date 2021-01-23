    using (var conn = new SqlConnection(@"Server=10.0.0.1;...") {
                    conn.Open();
                    .. Do work ..
                    conn.Close();
    }
    using (var conn = new SqlConnection(@"Server=SQLBox;…") {
                    conn.Open(); // This will *NOT* reuse the connection from the pool.
                    .. Do work ..
                    conn.Close();
    }
    using (var conn = new SqlConnection(@"Server=10.0.0.1;...") {
                    conn.Open(); // This *WILL* reuse the connection from the pool.
                    .. Do work ..
                    conn.Close();
    }
