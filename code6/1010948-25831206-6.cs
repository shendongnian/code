	enum PrefixCode { MW1, FW, DN, MWSTX1CK, MWSTX2FF, }
	enum TheseLetters {	Q, J, C, E, I, A, }
	struct CardRecord : IComparable<CardRecord> {
		public readonly PrefixCode Code;
		public readonly TheseLetters Letter;
		public readonly uint Number;
		public CardRecord(string input) {
			Code = ParseEnum<PrefixCode>(ref input);
			Letter = ParseEnum<TheseLetters>(ref input);
			Number = uint.Parse(input);
		}
		static T ParseEnum<T>(ref string input) { //assumes non-overlapping prefixes
			foreach(T val in Enum.GetValues(typeof(T))) {
				if(input.StartsWith(val.ToString())) {
					input = input.Substring(val.ToString().Length);
					return val;
				}
			}
			throw new InvalidOperationException("Failed to parse: "+input);
		}
		public int CompareTo(CardRecord other) {
			var codeCmp = Code.CompareTo(other.Code);
			if (codeCmp!=0) return codeCmp;
			var letterCmp = Letter.CompareTo(other.Letter);
			if (letterCmp!=0) return letterCmp;
			return Number.CompareTo(other.Number);
		}
		public override string ToString() {	
			return Code.ToString() + Letter + Number.ToString("00");
		}
	}
	
