    public class ReceiptsController : ApiController
    {
        public ReceiptsController()
        {
        }
    
        public List<Receipt> Get()
        {
            List<Receipt> receipts = new List<Receipt>();
            using (var context = new DbContext())
            {
                receipts = context.Receipts.ToList();
            }
    
            return View(receipts);
        }
    }
