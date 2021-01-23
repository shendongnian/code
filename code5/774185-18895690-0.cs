    public static class CreditMemos
    {
        public static List<CreditMemo> GetByDocumentNumber(string documentNumber)
        {
            return InvoiceRepository<CreditMemo>.CheckCache(new List<CreditMemo>());
        }
    }
    public static class InvoiceRepository<T>
        where T: DataObjects.Invoice
    {
        static List<T> invoiceCache = new List<T>();
    
        static internal List<T> CheckCache(List<T> results)
        {
            foreach (var result in results)
                if (!invoiceCache.Any(p => p.ID == result.ID))
                    invoiceCache.Add(result);
            return invoiceCache.Where(p => results.Any(a => a.ID == p.ID)).ToList();
        }
    }
