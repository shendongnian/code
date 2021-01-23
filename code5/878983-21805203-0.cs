     public class QueryDefinition
        {
            // The members doesn't need to be strings, can be whatever you use to handle the construction of the query.
            private string select;
            private string from;
            private string where;
    
            public QueryDefinition AddField(string select)
            {
                this.select = select;
                return this;
            }
    
            public QueryDefinition From(string from)
            {
                this.from = from;
                return this;
            }
    
            public QueryDefinition Where(string where)
            {
                this.where = where;
                return this;
            }
    
            public QueryDefinition AddFieldWithSubQuery(Action<QueryDefinition> definitionAction)
            {
                var subQueryDefinition = new QueryDefinition(); 
                definitionAction(subQueryDefinition);
    
                // Add here any action needed to consider the sub query, which should be defined in the object subQueryDefinition.
    
                return this;
            }
