    public class UserQuestionGroupMap : EntityTypeConfiguration<UserQuestionGroup>
    {
        public UserQuestionGroupMapping()
        {
            HasKey(uqg => new { uqg.UserId, uqg.QuestionGroupId });
            Property(uqg => uqg.Order).HasColumnName("Sort");
            HasRequired(uqg => uqg.User)
                .WithMany(u => u.QuestionGroups).HasForeignKey(uqg => uqg.UserId);
            HasRequired(uqg => uqg.QuestionGroup)
                .WithMany().HasForeignKey(uqg => uqg.QuestionGroupId);
        }
    }
