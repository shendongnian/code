    public interface IMyConnection
    {
        TModel Query<TModel>(string sql, object parms);
        int Execute(string sql, object parms);
    }
