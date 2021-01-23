    using Microsoft.SqlServer.TransactSql.ScriptDom;
    TSql110Parser parser = new TSql110Parser(true);
    IList<ParseError> errors = null;
    var condition = "a > 100; delete from [Recipes]";
    var script = parser.Parse(new StringReader("select [RecipeID] from [Recipes] where " + condition), out errors) as TSqlScript;
    if (errors.Count > 0)
    {
        throw new Exception(errors[0].Message);
    }
    foreach (var batch in script.Batches)
    {
        if (batch.Statements.Count == 1)
        {
            var select = batch.Statements[0] as SelectStatement;
            if (select != null)
            {
                QuerySpecification query = select.QueryExpression as QuerySpecification;
                if (query.WhereClause is BooleanBinaryExpression)
                {
                    ...
                }
            }
            else
            {
                throw new Exception("Select statement only allowed");
            }
        }
        else
        {
            throw new Exception("More than one statement detected");
        }
    }
