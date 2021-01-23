    [DefaultView("OverView")]
    public class OverViewService : Service
    {
        public OverViewResponse Get(OverViewRequest request)
        {
            return new OverViewResponse() { Name = "test" };
        }
    }
