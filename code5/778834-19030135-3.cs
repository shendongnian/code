    public class OverViewService : Service
    {
        [DefaultView("OverView")]
        public OverViewResponse Get(OverViewRequest request)
        {
            return new OverViewResponse() { Name = "test" };
        }
    }
