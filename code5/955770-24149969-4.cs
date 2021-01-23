    public class ParameterConfiguration : EntityTypeConfiguration<Parameter>
    {
        public ParameterConfiguration()
        {
            this.HasMany(t => t.Analyses)
                .WithMany(t => t.Parameters)
                .Map(m => m.ToTable("ParamsForAnalyses")
                    .MapLeftKey("ParameterId")
                    .MapRightKey("AnalysisId"));
        }
    }
    
