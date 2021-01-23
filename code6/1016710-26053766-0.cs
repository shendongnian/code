    public class TemplateContext : ContextBase<TemplateContext>, ITemplateContext
	{
		public DbSet<Template> Templates { get; set; }
		public DbSet<TemplateTask> TemplateTasks { get; set; }
		public DbSet<TemplateTaskDependancy> TemplateTaskDependancies { get; set; }
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
			modelBuilder.Configurations.Add(new TemplateTaskConfiguration());
		}
    }
