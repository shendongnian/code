    <connectionStrings>
    <add name="MovieDBContext" connectionString="Data Source=(LocalDb)\v11.0;AttachDbFilename=|DataDirectory|\aspnet-MVCmove-20140616082808.mdf;Initial Catalog=aspnet-MVCmove-20140616082808;Integrated Security=True" providerName="System.Data.SqlClient" />
    </connectionStrings>
    
    for the class
    
    using System;
    using System.Data.Entity;
    namespace MVCmove.Models
    {
    public class Movie
    {
    public int ID { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Default1Genre { get; set; }
    public decimal Price { get; set; }
    }
    public class MovieDBContext : DbContext {    
    public DbSet<Movie> Movies { get; set; }
    }
    }
