        public class InvoiceEntityConfig : EntityTypeConfiguration<InvoiceEntity>
        {
            public InvoiceEntityConfig()
            {
                this.Property(c => c.InvoiceXml).HasColumnType("xml");
                this.Ignore(c => c.Invoice);
            }
        }
