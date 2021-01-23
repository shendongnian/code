    public class MyClass : IDisposable
    {
        Connection con = new Connection();
        public void Dispose()
        {
            con.Dispose();
        }
    }
