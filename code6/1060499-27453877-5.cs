    public static class InvoiceExtensions
    {
        public static IEnumerable<KeyValuePair<ItemsChoiceType1, object>> ElementNamesAndItems<T>(this Invoice invoice)
        {
            return invoice.ItemsElementName.Zip(invoice.Items, (choice, item) => new KeyValuePair<ItemsChoiceType1, object>(choice, item)).Where(p => p.Value is T);
        }
    }
