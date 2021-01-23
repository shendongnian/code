    [Table("EntityA")]
    public partial class EntityA
    {
        public int EntityAId { get; set; }
        public string Description { get; set; }
        
        public virtual EntityB PrimaryEntityB { get; set; }
        public virtual EntityB AlternativeEntityB { get; set; }
        public bool IsDeleted { get; set; }
    }
    [Table("EntityB")]
    public partial class EntityB
    {
        public int EntityBId { get; set; }
        public string Description { get; set; }
        [InverseProperty("PrimaryEntityB")]
        public virtual ICollection<EntityA> EntityAsViaPrimary { get; set; }
        [InverseProperty( "AlternativeEntityB" )]
        public virtual ICollection<EntityA> EntityAsViaAlternative { get; set; }
    }
    public partial class TestEntities : DbContext
    {
        public TestEntities()
            : base("TestEntities")
        {
            Database.SetInitializer( new DatabaseInitializer() );
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntityA>()
                .Map( emc =>
                    {
                        emc.Requires( "IsDeleted" ).HasValue( false );
                    } )
                    .Ignore( a => a.IsDeleted );
        }
        public override int SaveChanges()
        {
            foreach( var entry in this.ChangeTracker.Entries<EntityA>() )
            {
                if( entry.State == EntityState.Deleted )
                {
                    SoftDelete( entry );
                }
            }
            return base.SaveChanges();
        }
        private void SoftDelete( DbEntityEntry entry )
        {
            var entityType = entry.Entity.GetType();
            var tableName = GetTableName( entityType );
            var pkName = GetPrimaryKeyName( entityType );
            var deleteSql = string.Format( "update {0} set IsDeleted = 1 where {1} = @id",
                tableName,
                pkName );
            Database.ExecuteSqlCommand( deleteSql, new SqlParameter( "@id", entry.OriginalValues[ pkName ] ) );
            entry.State = EntityState.Detached;
        }
        private string GetPrimaryKeyName( Type type )
        {
            return GetEntitySet( type ).ElementType.KeyMembers[ 0 ].Name;
        }
        private string GetTableName( Type type )
        {
            EntitySetBase es = GetEntitySet( type );
            return string.Format( "[{0}].[{1}]",
                es.MetadataProperties[ "Schema" ].Value,
                es.MetadataProperties[ "Table" ].Value );
        }
        private EntitySetBase GetEntitySet( Type type )
        {
            ObjectContext octx = ( ( IObjectContextAdapter )this ).ObjectContext;
            string typeName = ObjectContext.GetObjectType( type ).Name;
            var es = octx.MetadataWorkspace
                            .GetItemCollection( DataSpace.SSpace )
                            .GetItems<EntityContainer>()
                            .SelectMany( c => c.BaseEntitySets
                                            .Where( e => e.Name == typeName ) )
                            .FirstOrDefault();
            if( es == null )
                throw new ArgumentException( "Entity type not found in GetTableName", typeName );
            return es;
        }
        public DbSet<EntityA> EntityAs { get; set; }
        public DbSet<EntityB> EntityBs { get; set; }
    }
