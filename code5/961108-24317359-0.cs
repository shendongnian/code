			objectlist.Sort(delegate(Object a, Object b)
			{
				if (String.CompareOrdinal(a.Status, b.Status) == 0)
				{
					return String.CompareOrdinal(a.CustomerName, b.CustomerName) == 0 ? String.CompareOrdinal(a.CompanyName, b.CompanyName) : String.CompareOrdinal(a.BillingAddress, b.BillingAddress);
				}
				if (a.Status.Equals("Very Important!")) { return -1; }
				if (b.Status.Equals("Very Important!")) { return 1; }
				if (a.Status.Equals("Important")) { return -1; }
				if (b.Status.Equals("Important")) { return 1; }
				if (a.Status.Equals("Not Important")){ return -1; }
				return 1;
			});
