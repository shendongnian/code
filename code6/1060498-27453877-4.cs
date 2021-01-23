    public static class InvoiceExtensions
    {
        public static IEnumerable<Dates> Dates(this Invoice invoice)
        {
            return invoice.Items.OfType<Dates>();
        }
    }
