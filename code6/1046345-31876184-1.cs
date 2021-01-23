        // implementation in the proxy class:
		public IEnumerable<Stuff> GetLines()
		{
			var readToken = _dataService.StartReadingLines(...);
			try {
				for (List<Stuff> lines = _dataService.ReadNextLines(readToken); lines.Count > 0; lines = _dataService.ReadNextLines(readToken)) {
					foreach (var line in lines) {
						yield return line;
					}
				}
			} finally {
				_dataService.FinishReadingLines(readToken);
			}
		}
