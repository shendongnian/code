    this.Property(t => t.Site)
        .HasColumnName("MOV_SITE")
        .IsRequired();
    this.Property(t => t.MoveType)
        .HasColumnName("MOV_TYPE")
        .IsRequired();
    this.Property(t => t.Key)
        .HasColumnName("MOV_MOVE")
        .IsRequired();
