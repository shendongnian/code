        public class TaxRate : ITaxRate {
            private readonly IRepository repository;
            public TaxRate(IRepository repository) {
                this.repository = repository;
            }
            public decimal Get() {
                var item = repository.Get("CurrentTaxRate");
                return item.Value;
            }
        }
