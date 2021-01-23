	public class Factory
	{
		private Type _outputType = typeof(Animal);
		public void Produces<T>() where T : Animal, new()
		{
			_outputType = typeof(T);
		}
		public Animal CreateAnimal()
		{
			return (Animal)Activator.CreateInstance(_outputType);
		}
	}
