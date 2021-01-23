	public class Context
	{
		//Add as many of these as you want.  Don't forget to make public properties for them!
		private ObservableCollection<Staff> _staffs = new ObservableCollection<Staff>();
		private ObservableCollection<Contact> _contacts = new ObservableCollection<Contact>();
		private ObservableCollection<Dog> _dogs = new ObservableCollection<Dog>();
		
		
		private List<IForeignKeyRelation> _relations = new List<IForeignKeyRelation>();
		
		public Context()
		{
			var observables = this.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
				.ToList();
			
			foreach(var observable in observables)
			{
				var notifyCollection = observable.GetValue(this) as INotifyCollectionChanged;
				if (notifyCollection != null)
				{
					notifyCollection.CollectionChanged += CollectionChanged;
					Type principalType = observable.FieldType.GetGenericArguments()[0];
					
					var relations = principalType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
						.ToList()
						.Where(p => p.GetCustomAttribute(typeof(ForeignKeyAttribute)) as ForeignKeyAttribute != null)
						.Select(p => new { PrincipalForeignKeyInfo = p, ForeignKey = p.GetCustomAttribute(typeof(ForeignKeyAttribute)) as ForeignKeyAttribute })
						.Where(p => principalType.GetProperty(p.ForeignKey.Name) != null)
						.Select(p => {
							var principalForeignKeyInfo = p.PrincipalForeignKeyInfo;
							var principalRelationInfo = principalType.GetProperty(p.ForeignKey.Name);
							var dependantType = principalRelationInfo.PropertyType;
							var dependantKeyProperties = dependantType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
								.ToList()
								.Where(dp => dp.GetCustomAttribute(typeof(KeyAttribute)) as KeyAttribute != null)
								.ToList();
							var dependantKeyInfo = dependantKeyProperties.FirstOrDefault();
							
							var isValid = (dependantKeyInfo != null)
								// Don't allow INT to GUID comparisons
								// Keys need to be of same type;
								&& (principalForeignKeyInfo.PropertyType == dependantKeyInfo.PropertyType);
							
							
							return new {
								IsValid = isValid,
								PrincipalRelationInfo = principalRelationInfo,
								DependantType = dependantType,
								PrincipalCollection = observable.GetValue(this),
								PrincipalForeignKeyInfo = principalForeignKeyInfo,
								DependantKeyInfo = 	dependantKeyInfo							
							};
						})
						.Where(r => r.IsValid)
						.Select(r =>
						{			
							var relationType = typeof(ForeignKeyRelation<,>).MakeGenericType(principalType, r.DependantType);
							var relation = Activator.CreateInstance(relationType) as IForeignKeyRelation;
							relation.GetType().GetProperty("PrincipalCollection").SetValue(relation, observable.GetValue(this));
							relation.DependantKeyInfo = r.DependantKeyInfo;
							relation.PrincipalForeignKeyInfo = r.PrincipalForeignKeyInfo;
							relation.PrincipalRelationInfo = r.PrincipalRelationInfo;
							
							return relation;
						})
						.ToList();
					
					_relations.AddRange(relations);
				
				}
			}
		}
		
		// Makes storing Generic types easy when the
		// Generic type doesn't exist;
		private interface IForeignKeyRelation
		{
			PropertyInfo PrincipalForeignKeyInfo { get; set; } 
			PropertyInfo PrincipalRelationInfo { get; set; }
			PropertyInfo DependantKeyInfo { get; set; }
			void Add<T>(T value);
		}
		
		// Class to hold reflected values
		// Reflection 
		private class ForeignKeyRelation<P,D> : IForeignKeyRelation
		{
			// Staff.ContactId
			public PropertyInfo PrincipalForeignKeyInfo { get; set; } 
			public Collection<P> PrincipalCollection { get; set; }
			// Staff.Contact
			public PropertyInfo PrincipalRelationInfo { get; set; }
			// Contact.Id
			public PropertyInfo DependantKeyInfo { get; set; }
			
			public void Add<T>(T value)
			{
				if (value.GetType() == typeof(D))
				{
					var dependantKey = DependantKeyInfo.GetValue(value);
					
					var principals = PrincipalCollection.Where(p => this.PrincipalForeignKeyInfo.GetValue(p).Equals(dependantKey))
						.ToList();
					
					foreach(var principal in principals)
					{
						PrincipalRelationInfo.SetValue(principal, value);
					}
				}
			}
		}
		
		private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs args) 
		{
			switch (args.Action)
			{
				case NotifyCollectionChangedAction.Add:
					foreach(var relation in this._relations)
					{
						foreach(var item in args.NewItems)
						{
							relation.Add(item);
						}
					}
					break;
				case NotifyCollectionChangedAction.Move:
					break;
				case NotifyCollectionChangedAction.Remove:
					break;
				case NotifyCollectionChangedAction.Replace:
					break;
				case NotifyCollectionChangedAction.Reset:
					break;
				default:
					throw new NotImplementedException(args.Action.ToString());
			}
   		}
		
		public IList<Staff> Staffs
		{
			get
			{
				return _staffs;
			}
		}
		public IList<Contact> Contacts
		{
			get
			{
				return _contacts;
			}
		}
		public IList<Dog> Dogs
		{
			get
			{
				return _dogs;
			}
		}
	}
