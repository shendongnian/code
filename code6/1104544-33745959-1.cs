		public void ConfigureServices(IServiceCollection services)
		{
			services.AddEntityFramework()
				.AddNpgsql()
					.AddDbContext<YourDbContext>(options => options.UseNpgsql("your connectionString"))
				;
		}
