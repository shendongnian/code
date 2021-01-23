    static class Program {
		static void Main() {
			var inputStrings = @"MW1E10 MWSTX2FFI06 FWQ02 MW1Q04 MW1Q05 FWI01 MWSTX2FFA01 
						DNC03 MWSTX1CKC02 MWSTX2FFI03 MW1I06".Split().Where(s=>s!="");
			var outputStrings = inputStrings
				.Select(s => new CardRecord(s))
				.OrderBy(c => c)
				.Select(c => c.ToString());
			Console.WriteLine(string.Join("\n", outputStrings));
		}
	}
