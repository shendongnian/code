    ///
    /// Sample of a STRING or non int based enum concept.
    /// 
    
    public sealed class FilterOp {
        private static readonly Dictionary<string, FilterOp> EnumDictionary = new Dictionary<string, FilterOp>();
        private readonly string _name;
        private readonly string _value;
        public const string Eq = "Eq";
        public const string Ne = "Ne";
        public const string Gt = "Gt";
        public const string Ge = "Ge";
        public const string Lt = "Lt"; 
        public const string Le = "Le";
        public const string And = "And";
        public const string Or = "Or";
        public const string Not = "Not";
        public static readonly FilterOp OpEq = new FilterOp(Eq);
        public static readonly FilterOp OpNe = new FilterOp(Ne);
        public static readonly FilterOp OpGt = new FilterOp(Gt);
        public static readonly FilterOp OpGe = new FilterOp(Ge);
        public static readonly FilterOp OpLt = new FilterOp(Lt);
        public static readonly FilterOp OpLe = new FilterOp(Le);
        public static readonly FilterOp OpAnd = new FilterOp(And);
        public static readonly FilterOp OpOr = new FilterOp(Or);
        public static readonly FilterOp OpNot = new FilterOp(Not);
 
        private FilterOp(string name) {
            // extend to cater for Name / value pair, where name and value are different
            this._name = name;
            this._value = name;
            EnumDictionary[this._value] = this;
        }
        public override string ToString() {
            return this._name;
        }
        public string Name {
            get { return _name; }
        }
        public string Value {
            get { return _value; }
        }
        public static explicit operator FilterOp(string str) {
            FilterOp result;
            if (EnumDictionary.TryGetValue(str, out result)) {
                return result;
            }
            return null;
        }
    }
