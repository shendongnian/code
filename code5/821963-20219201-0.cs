		class Client
		{
			public int ClientID { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
		}
		[Flags]
		enum Criteria { 
			ClientID, FirstName, LastName
		}
		class ClientEqualityComparer : IEqualityComparer<Client> {
			private Criteria criteria;
			public ClientEqualityComparer(Criteria criteria) {
				this.criteria = criteria;
			}
			#region IEqualityComparer<Client> Membres
			public bool Equals(Client x, Client y)
			{
				if (criteria.HasFlag(Criteria.ClientID) && x.ClientID != y.ClientID)
					return false;
				if (criteria.HasFlag(Criteria.FirstName) && x.FirstName != y.FirstName)
					return false;
				if (criteria.HasFlag(Criteria.LastName) && x.LastName != y.LastName)
					return false;
				return true;
			}
			public int GetHashCode(Client obj)
			{
				int hash = 17;
				if (criteria.HasFlag(Criteria.ClientID))
					hash = hash * 31 + obj.ClientID;
				if (criteria.HasFlag(Criteria.FirstName))
					hash = hash * 31 + obj.FirstName;
				if (criteria.HasFlag(Criteria.LastName))
					hash = hash * 31 + obj.LastName;
			}
			#endregion
		}
		static void Main(string[] args)
		{
			IEnumerable<Client> orders;
			IEnumerable<Client> orders2;
			//...
			var matchingIdFn = orders.Intersect(orders2, 
				new ClientEqualityComparer(Criteria.ClientID | Criteria.FirstName));
			var matchingIdFnLn = orders.Intersect(orders2, 
				new ClientEqualityComparer(Criteria.ClientID | Criteria.FirstName | Criteria.LastName));
			var different = orders.Except(orders2, new ClientEqualityComparer(Criteria.ClientID | Criteria.FirstName));            
		}
