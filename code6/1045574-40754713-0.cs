    using StaticDotNet.EntityFrameworkCore.ModelConfiguration;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class ExampleEntityConfiguration
        : EntityTypeConfiguration<ExampleEntity>
    {
        public override void Configure( EntityTypeBuilder<ExampleEntity> builder )
        {
            //Add configuration just like you do in DbContext.OnModelCreating
        }
    }
