    using ExpressionFramework.Projections;
     
    namespace TestDTO
    {
        public class MyProjectionModel : ProjectionModel
        {
            protected override void OnModelCreating(ProjectionModelBuilder modelBuilder)
            {
                modelBuilder
                    .Projection<UserAccountDTO>()
                    .ForSource<UserAccountEntity>(configuration => 
                    {
                        configuration.Property(dto => dto.RoleCount).ExtractFrom(entity => entity.Roles.Count());
                    });
            }
        }
    }
