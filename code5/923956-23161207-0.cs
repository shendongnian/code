        public class AnswerSelectionTypeNHEntityMapping : ClassMap<AnswerSelectionTypeNHEntity>
        {
    
            public AnswerSelectionTypeNHEntityMapping()
            {
    
                Schema(Constants.ORGANIZATION_SCHEMA_NAME);
                Table("AnswerSelectionTypeNHEntity");
    
                Id(x => x.AnswerSelectionTypeNHEntityKey).GeneratedBy.Increment();
    
                Map(x => x.IDQuestionForm);
                Map(x => x.IDAssociateQuestion).Not.Nullable();
                Map(x => x.DataValue).Not.Nullable();
    
                References<QuestionNHEntity>(x => x.QuestionForm)
                    .Class(typeof(QuestionNHEntity))
                    /*.Not.Nullable() */
                     .Nullable()
                    .Column("ParentQuestionFormKey")
                    .Index("IX_AnswerSelectionType_ParentQuestionFormKey")
                    .Cascade.SaveUpdate()
                    ;
    
    
                References<QuestionNHEntity>(x => x.AssociateQuestion )
                    .Class(typeof(QuestionNHEntity))
                    /*.Not.Nullable() */
                     .Nullable()
                    .Column("OneToOneAssociateQuestionKey")
                    .Index("IX_AnswerSelectionType_OneToOneAssociateQuestionKeyy")
                    .Cascade.SaveUpdate()
                    ;
    
    
            }
    
    
        }
    
    
       public class QuestionNHEntityMapping : ClassMap<QuestionNHEntity>
        {
    
            public QuestionNHEntityMapping()
            {
    
                Schema(Constants.ORGANIZATION_SCHEMA_NAME);
                Table("QuestionNHEntity");
    
                Id(x => x.QuestionNHEntityKey).GeneratedBy.Assigned();
    
                Map(x => x.IDQuestion).Not.Nullable().Index("IX_Question_IDQuestion"); ;
                Map(x => x.IDForm).Not.Nullable();
    
    
    
                HasMany<AnswerSelectionTypeNHEntity>(x => x.AnswerSelectionTypes)
                    .Inverse()
                    .KeyColumns.Add("MyAnswerSelectionTypesColumnName")
                    ;
    
    
                References<AnswerSelectionTypeNHEntity>(x => x.AssociateAnswerSelectionType)
                    .Class(typeof(AnswerSelectionTypeNHEntity))
                    /*.Not.Nullable() */
                     .Nullable()
                    .Column("OneToOneAnswerSelectionTypeNHEntityKey")
                    .Index("IX_AnswerSelectionType_OneToOneAnswerSelectionTypeNHEntityKey")
                    .Cascade.SaveUpdate()
                    ;
    
    
    
            }
        }
