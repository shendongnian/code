    public List<T> SelectSqlItems<T>(string settingsgroup=null,int? state=null)
    {
        using(var context = new MyContext())
        {
             IQueyable<ApplicationSettings> query = context.ApplicationSettings;
             
             if(settingsgroup != null)
                 query = query.Where(row => row.settingsgroup = settingsgroup);
             if(state != null)
                 query = query.Where(row => row.state = state.Value)
    
             Expression<Func<ApplicationSettings, T>> selectExpression = GetSelectExpression<T>();
    
             return query.Select(selectExpression).ToList();
        }
    }
