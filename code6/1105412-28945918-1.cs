    public class DisciplineMap : EntityTypeConfiguration<Discipline>
    {
        public DisciplineMap()
        {
            ToTable("Discipline");
            HasKey(p => p.Id);
        }
    }
    public class DisciplineRequirementMap : EntityTypeConfiguration<DisciplineRequeriment>
    {
        public DisciplineRequirementMap()
        {
            ToTable("DisciplineRequirement");
            HasKey(p => new
            {
                p.DisciplineId,
                p.RequiredDisciplineId
            });
            HasRequired(p => p.Discipline)
                .WithMany(p => p.RequiredBy)
                .HasForeignKey(p => p.DisciplineId);
            HasRequired(p => p.RequiredDiscipline)
                .WithMany(p => p.Requirements)
                .HasForeignKey(p => p.RequiredDisciplineId);
        }
    }
