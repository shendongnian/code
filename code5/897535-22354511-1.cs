            var param = Expression.Parameter(typeof(MyEntity));
            dynamic propertyExpression = Expression.Lambda(Expression.Property(param, "MyProperty"), param);
            modelBuilder.Entity<MyEntity>()
                .Property(propertyExpression)
                .HasColumnName("FishFace");
