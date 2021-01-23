    public class fileHistory : List<Object>
    {
        public new void Add(DateTime ts, int st)
        {
            base.Add( new { timeStamp = ts, status = st} );
        }
    }
