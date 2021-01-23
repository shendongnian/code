    public class BusinessObject {
        public class Poco {
            public readonly BusinessObject BusinessObject;
            public Poco(BusinessObject businessObject) {
                this.BusinessObject = businessObject;
            }
            public Poco() {
                this.BusinessObject = new BusinessObject();
            }
            public string Id {
                get { return this.BusinessObject.Id; }
                set { this.BusinessObject.Id = value; }
            }
            public decimal Amount {
                get { return this.BusinessObject.Amount; }
                set { this.BusinessObject.Amount = value; }
            }
            public DateTime Dt {
                get { return this.BusinessObject.Dt.ToDateTime(); }
                set { this.BusinessObject.Dt = LocalDateTime.FromDateTime(value).Date; }
            }
            public string TimeZone {
                get { return this.BusinessObject.TimeZone.Id; }
                set { this.BusinessObject.TimeZone = DateTimeZoneProviders.Tzdb.GetZoneOrNull(value); }
            }
            public string Description {
                get { return this.BusinessObject.Description; }
                set { this.BusinessObject.Description = value; }
            }
        }
        public string Id { get; private set; }
        public decimal Amount { get; private set; }
        public LocalDate Dt { get; private set; }
        public DateTimeZone TimeZone { get; private set; }
        public string Description { get; private set; }
        public BusinessObject() { }
        public BusinessObject(string id, decimal amount, LocalDate dt, DateTimeZone timeZone, string description) {
            this.Id = id;
            this.Amount = amount;
            this.Dt = dt;
            this.TimeZone = timeZone;
            this.Description = description;
        }
    }
