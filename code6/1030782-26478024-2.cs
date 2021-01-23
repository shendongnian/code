        public class NoteConfig : EntityTypeConfiguration<Note>
        {
            public NoteConfig()
            {
                this.HasKey(p => p.Id).Property(p1 => p1.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //this.HasRequired(p => p.Text);
             }
        }
