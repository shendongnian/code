            modelBuilder.Entity<PostTag>()
                .HasOne(pt => pt.Tag)
                .WithMany(t => t.PostTags)
                .HasForeignKey(pt => pt.TagId);
            public class PostTag
            {
              public int PostId { get; set; }
              public Post Post { get; set; }
              public int TagId { get; set; }
              public Tag Tag { get; set; }
            }
