    public class CarComparer : IComparer<Car>
    {
        public int Compare(Car x, Car y)
        {
            // compare by system id first
            var order = string.Compare(x.SystemId, y.SystemId);
            if (order != 0)
                return order;
            // try to cast both items as CarRent
            var xRent = x as CarRent;
            var yRent = y as CarRent;
            if (xRent != null && yRent != null)
                return DateTime.Compare(xRent.RentEndDate, yRent.RentEndDate);
            // try to cast both items as CarPurchase
            var xPurc = x as CarPurchase;
            var yPurc = y as CarPurchase;
            if (xPurc != null && yPurc != null)
                return decimal.Compare(xPurc.Mileage, yPurc.Mileage);
            // now, this is awkward
            return 0;
        }
    }
