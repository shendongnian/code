    public class StockDates {
        public StockDates(IEnumerable<PurchaseOrder> purchaseOrders) {
        }
        public StockData GetByDay(int day) {
            // Create an object from the purchaseOrders brought in from the constructor
        }
        public Dictionary<int, StockData> GetStockDataGroupedByDay() {
            // Create a dictionary keyed by the day number
        }
    }
