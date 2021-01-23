	public interface ITable
	{
		int Id { get; set; }
	}
        public virtual async Task<T> Get(int id) where T : ITable
        {
           ... 
