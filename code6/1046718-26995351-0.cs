			var groups = testList.GroupBy(_ => _.Name);
			IEnumerable<IEnumerable<TestParam>> result = null;
			foreach (var g in groups)
			{
				var current = g.Select(_ => new[] { _ });
				if (result == null)
				{
					result = current;
					continue;
				}
				result = result.Join(current, _ => true, _ => true, (actual, c) => actual.Concat(c));
			}
			// check result
			foreach (var i in result)
			{
				Console.WriteLine(string.Join(", ", i.Select(_ => string.Format("{0}-{1}", _.Name, _.Value))));
			}
