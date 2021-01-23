    public class Vector
	{
		private List<int> _timeElements = new List<int>();
    
        public Vector(int[] times)
        {
            Add(times);
        }
		public void Add(int time)
		{
			_timeElements.Add(time);
		}
		public void Add(int[] times)
		{
			_timeElements.AddRange(time);
		}
		public void Remove(int time)
		{
			_timeElements.Remove(time);
			if (OnRemove != null)
				OnRemove(this, time);
		}
		public List<int> Elements { get { return _timeElements; } }
		public event Action<Vector, int> OnRemove;
	}
	public class Vectors
	{
		private Dictionary<int, List<Vector>> _timeIndex;
		public Vectors(int maxTimeSize)
		{
			_timeIndex = new Dictionary<int, List<Vector>>(maxTimeSize);
			for (var i = 0; i < maxTimeSize; i++)
				_timeIndex.Add(i, new List<Vector>());
			List = new List<Vector>();
		}
		public List<Vector> FindVectorsByTime(int time)
		{
			return _timeIndex[time];
		}
		public List<Vector> List { get; private set; }
		public void Add(Vector vector)
		{
			List.Add(vector);
			vector.Elements.ForEach(element => _timeIndex[element].Add(vector));
				vector.OnRemove += OnRemove;
		}
		private void OnRemove(Vector vector, int time)
		{
			_timeIndex[time].Remove(vector);
		}
	}
