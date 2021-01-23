    public class InaccessibleFKDependent
    {
        [Key]
        public int Id { get; set; }
        private int? PrincipalId { get; set; }
        private InaccessibleFKPrincipal _principal;
        public virtual InaccessibleFKPrincipal Principal
        {
            get => _principal;
            set
            {
                if( null == value )
                {
                    PrincipalId = null;
                }
                
                _principal = value;
            }
        }
    }
    public class InaccessibleFKDependentConfiguration : IEntityTypeConfiguration<InaccessibleFKDependent>
    {
        public void Configure( EntityTypeBuilder<InaccessibleFKDependent> builder )
        {
            builder.HasOne( d => d.Principal )
                .WithMany()
                .HasForeignKey( "PrincipalId" );
        }
    }
 
