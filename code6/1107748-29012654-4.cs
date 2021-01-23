     public class CodesMap : EntityTypeConfiguration<CODES>
     {
        public CodesMap()
        {
            // Primary Key
            this.HasKey(t => t.CODE);
        }
     }
     
     public class AggregationsMap : EntityTypeConfiguration<AGGREGATIONS>
     {
        public AggregationsMap()
        {
            // Primary Key
            this.HasKey(t => t.ID_AGGREGATION);
            HasRequired(ag => ag.Code).WithOptional(c => c.Aggregation);
        }
     }
     public class AggregationChildsMap : EntityTypeConfiguration<AGGREGATIONS_CHILDS>
     {
        public AggregationChildsMap()
        {
            // Primary Key
            this.HasKey(t => new{t.CODE,t.ID_AGGREGATION});
            HasRequired(t => t.Code).WitMany(c => c.AggregationChilds).HasForeignKey(t=>t.CODE);
            HasRequired(t => t.Aggregation).WitMany(ag => ag.AggregationChilds).HasForeignKey(t=>t.ID_AGGREGATION);
          
        }
     }
 
