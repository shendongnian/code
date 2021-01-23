    public class ProfileMap : EntityTypeConfiguration<Profile>
    {
        public IdentityUserMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Properties
            this.Property(t => t.Id)
                .IsRequired()
                .HasMaxLength(128);
            this.Property(t => t.CompanyId)
                .IsRequired()
                .HasMaxLength(128);
            this.Property(t => t.CreatedById)
                .IsRequired()
                .HasMaxLength(128);
            this.Property(t => t.ModifiedById)
                .HasMaxLength(128);
            this.Property(t => t.Title)
                .IsRequired();
            this.Property(t => t.Forename)
                .IsRequired();
            this.Property(t => t.Surname)
                .IsRequired();
            this.Property(t => t.Email)
                .IsRequired();
            this.Property(t => t.CredentialId)
                .IsRequired();
            this.Property(t => t.PasswordHash)
                .HasMaxLength(128);
            this.Property(t => t.SecurityStamp)
                .HasMaxLength(128);
            this.Property(t => t.Discriminator)
                .HasMaxLength(128);
            // Table & Column Mappings
            this.ToTable("Profiles");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.CompanyId).HasColumnName("CompanyId");
            this.Property(t => t.CreatedById).HasColumnName("CreatedById");
            this.Property(t => t.ModifiedById).HasColumnName("ModifiedById");
            this.Property(t => t.DateCreated).HasColumnName("DateCreated");
            this.Property(t => t.DateModified).HasColumnName("DateModified");
            this.Property(t => t.LastLoginDate).HasColumnName("LastLoginDate");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Forename).HasColumnName("Forename");
            this.Property(t => t.Surname).HasColumnName("Surname");
            this.Property(t => t.Email).HasColumnName("Email");
            this.Property(t => t.JobTitle).HasColumnName("JobTitle");
            this.Property(t => t.Telephone).HasColumnName("Telephone");
            this.Property(t => t.Mobile).HasColumnName("Mobile");
            this.Property(t => t.Photo).HasColumnName("Photo");
            this.Property(t => t.LinkedIn).HasColumnName("LinkedIn");
            this.Property(t => t.Twitter).HasColumnName("Twitter");
            this.Property(t => t.Facebook).HasColumnName("Facebook");
            this.Property(t => t.Google).HasColumnName("Google");
            this.Property(t => t.Bio).HasColumnName("Bio");
            this.Property(t => t.CompanyName).HasColumnName("CompanyName");
            this.Property(t => t.CredentialId).HasColumnName("CredentialId");
            this.Property(t => t.IsLockedOut).HasColumnName("IsLockedOut");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.CanEditOwn).HasColumnName("CanEditOwn");
            this.Property(t => t.CanEdit).HasColumnName("CanEdit");
            this.Property(t => t.CanDownload).HasColumnName("CanDownload");
            this.Property(t => t.RequiresApproval).HasColumnName("RequiresApproval");
            this.Property(t => t.CanApprove).HasColumnName("CanApprove");
            this.Property(t => t.CanSync).HasColumnName("CanSync");
            this.Property(t => t.AgreedTerms).HasColumnName("AgreedTerms");
            this.Property(t => t.Deleted).HasColumnName("Deleted");
            this.Property(t => t.UserName).HasColumnName("UserName");
            this.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            this.Property(t => t.SecurityStamp).HasColumnName("SecurityStamp");
            this.Property(t => t.Discriminator).HasColumnName("Discriminator");
            // Relationships
        }
    }
