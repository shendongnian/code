	public class Person : ReactiveObject, IEditableObject
	{
		private readonly ISubject<Unit> changedDuringEdit = new Subject<Unit>();
		private string name;
		private string nameCopy;
		
	
		public string Name
		{
			get { return this.name; }
			set { this.RaiseAndSetIfChanged(ref this.name, value); }
		}
	
		public void BeginEdit()
		{
			this.nameCopy = this.name;
		}
	
		public void CancelEdit()
		{
			this.name = this.nameCopy;
		}
	
		public void EndEdit()
		{
			if(!string.Equals(this.nameCopy, this.name))
			{
				changedDuringEdit.OnNext(Unit.Default);
			}
		}
		
		public IObservable<Unit> ChangedDuringEdit
		{
			get { return this.changedDuringEdit.AsObservable(); }
		}
	}
