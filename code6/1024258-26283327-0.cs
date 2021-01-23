    modelBuilder
        .Entity<Foo>()
        .Property(t => t.X)
        .IsRequired()
        .HasMaxLength(60)
        .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_X_Y", 1) { IsUnique = true }));
    modelBuilder
        .Entity<Foo>()
        .Property(t => t.Y)
        .IsRequired()
        .HasColumnAnnotation(IndexAnnotation.AnnotationName, new IndexAnnotation(new IndexAttribute("IX_X_Y", 2) { IsUnique = true }));
