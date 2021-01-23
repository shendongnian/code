            builder.Entity<ContactRecord>()
                .HasRequired(p => p.CreatedBy)
                .WithMany()
                .HasForeignKey(p => p.CreatedBy_OperatorId)
                .WillCascadeOnDelete(false);
            builder.Entity<ContactRecord>()
                .Property(p => p.CreatedBy_OperatorId)
                .HasColumnName("CreatedBy_OperatorId");
            builder.Entity<ContactRecord>()
                .HasRequired(p => p.ModifiedBy)
                .WithMany()
                .HasForeignKey(p => p.ModifiedBy_OperatorId)
                .WillCascadeOnDelete(false);
            builder.Entity<ContactRecord>()
                .Property(p => p.ModifiedBy_OperatorId)
                .HasColumnName("ModifiedBy_OperatorId");
