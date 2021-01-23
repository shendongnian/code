	public abstract class Translator {
		public abstract object Serialize(object obj);
		public abstract object Deserialize(object obj);
	}
	public class Translator<TOriginal, TSerialized> : Translator {
		private readonly Func<TOriginal, TSerialized> _Serialize;
		private readonly Func<TSerialized, TOriginal> _Deserialize;
		public Translator(Func<TOriginal, TSerialized> serialize, Func<TSerialized, TOriginal> deserialize) {
			this._Serialize = serialize;
			this._Deserialize = deserialize;
		}
		public override object Serialize(object obj) {
			return new ReplacementType { Serialized = this._Serialize((TOriginal)obj), OriginalTypeFullName = typeof(TOriginal).FullName };
		}
		public override object Deserialize(object obj) {
			return this._Deserialize((TSerialized)obj);
		}
	}
