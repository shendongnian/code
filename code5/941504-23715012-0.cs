    IEnumerable<GroupResult> GetGroups(string userName)
    {
        foreach(var group in context.Groups.Where(g => <some user-specific condition>))
        {
            var result = new GroupResult()
            ... // Further compose the result.
            
            yield return result;
            
        }
    }
    
