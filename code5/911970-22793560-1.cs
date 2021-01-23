    public IEnumerable<Comic> ExpensiveIssues
    {
        get 
        {
            var result = from issue in issues where issue.Price >= 10 select issue;
            return result as IEnumerable<Comic>;
        }
    }
