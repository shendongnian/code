      public static class EnumerableExtensions {
                
        public static IEnumerable<Invoice> SendEmail(this IEnumerable<Invoice> invoices) {
            foreach (var invoice in invoices) {
                SendEmail(invoice.Customer);
                yield return invoice;
            }
        }        
        
        public static IEnumerable<Invoice> ShipProduct(this IEnumerable<Invoice> invoices) {
            foreach (var invoice in invoices) {
                ShipProduct(invoice.Customer, invoice.Product, invoice.Quantity);
                yield return invoice;
            }
        }                     
    
        public static IEnumerable<Invoice> AdjustInventory(this IEnumerable<Invoice> invoices) {
            foreach (var invoice in invoices) {
                AdjustInventory(invoice.Product, invoice.Quantity);
                yield return invoice;
            }
        }
    
    
        private static void SendEmail(object p) {
            Console.WriteLine("Email!");
        }
        private static void AdjustInventory(object p1, object p2) {
            Console.WriteLine("Adjust inventory!");
        }
        private static void ShipProduct(object p1, object p2, object p3) {
            Console.WriteLine("Ship!");
        }
    }
    
