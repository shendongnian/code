    using System.Text.Json;
    builder.Entity<YourEntity>().Property(p => p.Strings)
        .HasConversion(
            v => JsonSerializer.Serialize(v, default),
            v => JsonSerializer.Deserialize<List<string>>(v, default));
