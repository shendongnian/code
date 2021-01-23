    public class ScheduleInfoMapping : NHibernateClassMapping<ScheduleInfo>
        {
            public ScheduleInfoMapping()
            {
                DiscriminateSubClassesOnColumn("Type");
                Map(x => x.Detail).MapAsLongText();
                Map(x => x.StartDate);
            }
        }
