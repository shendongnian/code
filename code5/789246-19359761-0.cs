    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    
    namespace MyDatabaseProject.Conventions
    {
        public class UnderscoreTableNameConvention : IClassConvention
        {
            public void Accept(IAcceptanceCriteria<IClassInspector> criteria)
            {
               
            }
            public void Apply(IClassInstance instance)
            {
                instance.Table("_" + instance.TableName);
            }
        }
    }
