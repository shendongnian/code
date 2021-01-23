    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    namespace SO22928136
    {
        public interface IMyDbContext : IDisposable
        {
            IDbSet<Article> Articles { get; set; }
            IDbSet<ArticleScore> ArticleScores { get; set; }
            int SaveChanges();
        }
        public class MyDbContext : DbContext, IMyDbContext
        {
            public IDbSet<Article> Articles { get; set; }
            public IDbSet<ArticleScore> ArticleScores { get; set; }
            static MyDbContext()
            {
                Database.SetInitializer(new DropCreateDatabaseAlways<MyDbContext>());
            }
            public MyDbContext(string connectionString) : base(connectionString)
            {
            }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
                modelBuilder.Configurations.Add(new ArticleConfiguration());
                modelBuilder.Configurations.Add(new ArticleScoreConfiguration());
            }
        }
        public class Article
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public virtual ICollection<ArticleScore> ArticleScores { get; set; }
            public Article()
            {
                ArticleScores = new List<ArticleScore>();
            }
        }
        public class ArticleScore
        {
            public int Id { get; set; }
            public int ArticleId { get; set; }
            public string ActualCity { get; set; }
            public virtual Article Article { get; set; }
        }
        internal class ArticleConfiguration : EntityTypeConfiguration<Article>
        {
            public ArticleConfiguration()
            {
                ToTable("Article");
                HasKey(x => x.Id);
                Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(x => x.Title).HasColumnName("Title").IsOptional();
            }
        }
        internal class ArticleScoreConfiguration : EntityTypeConfiguration<ArticleScore>
        {
            public ArticleScoreConfiguration()
            {
                ToTable("ArticleScore");
                HasKey(x => x.Id);
                Property(x => x.Id).HasColumnName("Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(x => x.ArticleId).HasColumnName("ArticleId").IsRequired();
                Property(x => x.ActualCity).HasColumnName("ActualCity").IsOptional().HasMaxLength(10);
                HasRequired(a => a.Article).WithMany(b => b.ArticleScores).HasForeignKey(c => c.ArticleId);
            }
        }
        class Program
        {
            static void Main()
            {
                MyDbContext context = new MyDbContext("Data Source=(local);Initial Catalog=SO22928136;Integrated Security=True;");
                CreateTestData(context);
                
                var countOfArticlesPerCity = context.ArticleScores.GroupBy(s => new {s.ArticleId, s.ActualCity}).Select(g => new {g.Key.ArticleId, g.Key.ActualCity, Count = g.Count()});
                var highestArticleCountPerCity = countOfArticlesPerCity.GroupBy(x => x.ActualCity).Select(g => g.OrderByDescending(x => x.Count).FirstOrDefault());
                var highestArticleCountPerCityWithArticleTitle = context.Articles.Join(highestArticleCountPerCity, x => x.Id, p => p.ArticleId, (x, p) => new { x.Title, p.ActualCity, p.Count });
                foreach (var line in highestArticleCountPerCityWithArticleTitle)
                {
                    Console.WriteLine("{0}, {1}({2})",line.Title,line.ActualCity, line.Count);
                }
            }
            private static void CreateTestData(MyDbContext context)
            {
                Article articleOne = new Article { Title = "TitleOneOfArticles" };
                Article articleTwo = new Article { Title = "TitleTwoOfArticles" };
                articleOne.ArticleScores.Add(new ArticleScore { ActualCity = "NewYork" });
                articleOne.ArticleScores.Add(new ArticleScore { ActualCity = "NewYork" });
                articleOne.ArticleScores.Add(new ArticleScore { ActualCity = "NewYork" });
                articleOne.ArticleScores.Add(new ArticleScore { ActualCity = "Boston" });
                articleTwo.ArticleScores.Add(new ArticleScore { ActualCity = "NewYork" });
                articleTwo.ArticleScores.Add(new ArticleScore { ActualCity = "Boston" });
                articleTwo.ArticleScores.Add(new ArticleScore { ActualCity = "Boston" });
                context.Articles.Add(articleOne);
                context.Articles.Add(articleTwo);
                context.SaveChanges();
            }
        }
    }
