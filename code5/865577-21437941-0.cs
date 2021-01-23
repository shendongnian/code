    public class OnSaleSpecification<T> : Specification<T> where T : ISellingItem
    {
        public override bool IsSatisfiedBy(T item)
        {
            return item.IsOnSale;
        }
    }
