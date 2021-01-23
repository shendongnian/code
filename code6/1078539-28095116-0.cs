	public class Entity 
	{
		public string Id { get; set; }
		public string State { get; set; }
	}
	
	public class EntityViewModel : ViewModelBase
	{
		private string _state;
		
		public EntityViewModel(Entity entity)
		{
			Entity = entity;
			_state = entity.State;
		}
		
		public string State
		{
			get { return _state; }
			set
			{
				if (value == _state)
					return;
				_state = value;
				base.OnPropertyChanged("State");
			}
		}
		
		public Entity Entity {get; private set; }
		
		public void ApplyChanges()
		{
			Entity.State = _state;
		}
		
		public void Undo()
		{
			State = entity.State;
		}
	}
