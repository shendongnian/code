    namespace invoiceViewer.Controllers
    {
        public class invoiceController : ApiController
        {
            public invoiceController() {}
            public void DoStuff()
            {
                foo data = InvoiceDAL.GetFooData();
            }
        }
    }
