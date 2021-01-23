    public class Helper
    {
        Random _r = new Random();
        public string GetUniqueId()
        {
            int n = _r.Next(9);
            return String.Format("{0:yyyyMMddHHmmss}{1}", DateTime.Now, n.ToString());
        }
    }
