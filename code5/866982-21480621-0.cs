    [Serializable()]                
    public sealed class Union<A,B> : IEquatable<Union<A,B>>
    {
            private enum TypeTag{ A, B};
            private Union ()
            {
            }
            private A AValue;
            private B BValue;
            private TypeTag tag;
            public static Union<A,B> CreateA (A a)
            {
                    var u = new Union<A,B> ();
                    u.AValue = a;
                    u.tag = TypeTag.A;
                    return u;
            }
            public static Union<A,B> CreateB (B b)
            {
                    var u = new Union<A,B> ();
                    u.BValue = b;
                    u.tag = TypeTag.B;
                    return u;
            }
            public U SelectOn<U> (Func<A, U> withA, Func<B, U> withB)
            {
                    if (withA == null)
                            throw new ArgumentNullException ("withA");
                    if (withB == null)
                            throw new ArgumentNullException ("withB");
                    if (tag == TypeTag.A)
                    {
                            return withA (AValue);
                    } 
                    else if (tag == TypeTag.B) 
                    {
                            return withB (BValue);
                    }
            
                    throw new InvalidOperationException ("Unreachable code.");
            }
            public void Run (Action<A> actionIfA, Action<B> actionIfB)
            {
                    if (actionIfA == null)
                            throw new ArgumentNullException ("actionIfA");
                    if (actionIfB == null)
                            throw new ArgumentNullException ("actionIfB");
                    if (tag == TypeTag.A) 
                    {
                            actionIfA (AValue);
                    } 
                    else if (tag == TypeTag.B) 
                    {
                            actionIfB (BValue);
                    }
            }
            public void Run (Action<A> actionIfA)
            {
                    if (actionIfA == null)
                            throw new ArgumentNullException ("actionIfA");
                    if (tag == TypeTag.A) 
                    {
                            actionIfA (AValue);
                    }
            }
            public void Run (Action<B> actionIfB)
            {
                    if (actionIfB == null)
                            throw new ArgumentNullException ("actionIfB");
                    if (tag == TypeTag.B) {
                            actionIfB (BValue);
                    }
            }
            public override string ToString ()
            {
                    if (tag == TypeTag.A) 
                    {
                            return "Type A" + typeof(A).ToString() + ": " + AValue.ToString();
                    } 
                    else if (tag == TypeTag.B) {
                            return "Type B" + typeof(B).ToString() + ": " + BValue.ToString();
                    }
                    throw new InvalidOperationException ("Unreachable code.");
            }
            public override int GetHashCode()
            {
                unchecked
                {
                    int result = tag.GetHashCode();
                            if (tag == TypeTag.A) {
                                    result = (result * 397) ^ (AValue != null ? AValue.GetHashCode() : 0);
                            } else if (tag == TypeTag.B) {
                                    result = (result * 397) ^ (BValue != null ? BValue.GetHashCode() : 0);
                            }
                    return result;
                }
            }
            public override bool Equals (object other)
            {
                    if (other is Union<A,B>)
                    {
                            return this.Equals((Union<A,B>)other);
                    }
                    return false;
            }
            public bool Equals (Union<A,B> other)
            {
                    if (this.tag != other.tag) 
                    {
                            return false;
                    }
                if (tag == TypeTag.A) 
                {
                            return this.AValue.Equals(other.AValue);
                    } 
                    else if (tag == TypeTag.B) 
                    {
                            return this.AValue.Equals(other.AValue);
                    }
                    return false;
            }
    }
	
