    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.AcceptanceCriteria;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestingNhibernate
    {
        public class UnderscoreTableNameConvention : IClassConvention, IJoinedSubclassConvention,  ICollectionConvention
        {
            public readonly string PrependToTableName = "_"; 
           
            public void Apply(IClassInstance instance)
            {
                instance.Table(GetTableName(instance.EntityType.Name));
            }
    
            public void Apply(IJoinedSubclassInstance instance)
            {
                instance.Table(GetTableName(instance.EntityType.Name));
            }
    
            public void Apply(ICollectionInstance instance)
            {
                instance.Table(GetTableName(instance.EntityType.Name));
            }
    
            private string GetTableName(string originalName)
            {
                return string.Format("`{0}{1}`", PrependToTableName, originalName);
            }
        }
    }
