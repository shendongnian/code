	using System.Threading.Tasks;
	...
	public IEnumerable<Chunk> GetChunks()
	{
		// Here you can return the whole chunks collection or yield them one by one.
		yield return new Chunk();
	}
	public void DoIt()
	{
		ChunkBuilder builder = new ChunkBuilder();
		ParallelOptions options = new ParallelOptions() {
			MaxDegreeOfParallelism = 4
		};
		Parallel.ForEach(this.GetChunks(), options, chunk => builder.Generate(chunk));
	}
