    public class StatusHelper
    {
        private Dictionary<Status, Image> _map;
        public StatusHelper()
        {
            _map = new Dictionary<Status, Image>()
                           {
                               {Status.New, new Image()},
                               {Status.Dropped, new Image()},
                               {Status.Approved, new Image()},
                           };
        }
        public Image GetImageForStatus(Status status)
        {
            return _map[status];
        }
    }
