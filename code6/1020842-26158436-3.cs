        public partial class SomeConnection
        {
            private readonly bool correctConstructorWasCalled;
            public DerivedContext(string connectionString)
                :base(connectionString)
            {
                correctConstructorWasCalled = true;
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                if (!correctConstructorWasCalled)
                {
                    throw new InvalidOperationException("Please call the correct constructor.");
                }
                base.OnModelCreating(modelBuilder);
            }
        }
