    protected override void Seed(YourContext context)
    {
        context.Database
                .ExecuteSqlCommand(Load("YourProject.Migrations.Sql.drop.sql"));
        context.Database
                .ExecuteSqlCommand(Load("YourProject.Migrations.Sql.view1.sql"));
        context.Database
                .ExecuteSqlCommand(Load("YourProject.Migrations.Sql.view2.sql"));
        context.Database
                .ExecuteSqlCommand(Load("YourProject.Migrations.Sql.function1.sql"));
        context.Database
                .ExecuteSqlCommand(Load("YourProject.Migrations.Sql.function2.sql"));
        context.Database
                .ExecuteSqlCommand(Load("YourProject.Migrations.Sql.procedure1.sql"));
        context.Database
                .ExecuteSqlCommand(Load("YourProject.Migrations.Sql.procedure2.sql"));
    }
