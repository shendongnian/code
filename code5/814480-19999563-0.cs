    public abstract class JToken : IJEnumerable<JToken>,
          System.Collections.Generic.IEnumerable<JToken>, IEnumerable,
          IJsonLineInfo, ICloneable, IDynamicMetaObjectProvider
    {
        // ...
        public static implicit operator JToken(string value);
        // ...
    }
