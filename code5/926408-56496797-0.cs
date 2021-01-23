    public static class MethodInfoUtil
    {
        static readonly Regex MagicTagPattern = new Regex(">([a-zA-Z]+)__");
        static readonly string AnonymousMagicTag;
        static readonly string InnerMagicTag;
        public static bool IsAnonymous(this MethodInfo mi)
        {
            return mi.Name.Contains(AnonymousMagicTag);
        }
        public static bool IsInner(this MethodInfo mi)
        {
            return mi.Name.Contains(InnerMagicTag);
        }
        public static string GetNameMagicTag(this MethodInfo mi, bool noThrow = false)
        {
            var match = MagicTagPattern.Match(mi.Name);
            if (match.Success && match.Value is string value && !match.NextMatch().Success)
                return value;
            else if (noThrow)
                return null;
            else
                throw new ArgumentException($"Cant find magic tag of {mi}");
        }
        // static constructor: initialize the magic tags
        static MethodInfoUtil()
        {
            void Inner() { };
            Action inner = Inner;
            Action anonymous = () => { };
            InnerMagicTag = GetNameMagicTag(inner.Method);
            AnonymousMagicTag = GetNameMagicTag(anonymous.Method);
            CheckThatItWorks();
        }
        [Conditional("DEBUG")]
        static void CheckThatItWorks()
        { 
            // Static mathods are neither anonymous nor inner
            Debug.Assert(!((Func<int, int>)Math.Abs).Method.IsAnonymous());
            Debug.Assert(!((Func<int, int>)Math.Abs).Method.IsInner());
            // Instance methods are neither anonymous nor inner
            Debug.Assert(!((Func<string, bool>)"".StartsWith).Method.IsAnonymous());
            Debug.Assert(!((Func<string, bool>)"".StartsWith).Method.IsInner());
            // Lambda 
            Action anonymous1 = () => { };
            Debug.Assert(anonymous1.Method.IsAnonymous());
            Debug.Assert(!anonymous1.Method.IsInner());
            // Anonymous delegates 
            Action anonymous2 = delegate(){ };
            Debug.Assert(anonymous2.Method.IsAnonymous());
            // Sublambdas 
            Action anonymous3 = new Func<Func<Action>>(() => () => () => { })()();
            Debug.Assert(anonymous3.Method.IsAnonymous());
            void Inner() { }
            Action inner1 = Inner;
            Debug.Assert(inner1.Method.IsInner());
            Debug.Assert(!inner1.Method.IsAnonymous());
            // Deep inner methods have same tag as inner
            Action Imbricated()
            {
                void Inside() { };
                return Inside;
            }
            Action inner2 = Imbricated();
            Debug.Assert(inner2.Method.IsInner());
        }
    }
 
