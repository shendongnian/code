        public static T InjectClone<T>(this T source)
        {
        //note: you have to implements HasCopyConstractor & HasDefualtConstractor...
            if (source is ICloneable)
                return (T) ((ICloneable) source).Clone();
            var type = source.GetType();
            if (HasCopyConstractor(type))
                return (T) Activator.CreateInstance(type, source);
            if (HasDefualtConstractor(type))
            {
                var target = (T) Activator.CreateInstance(source.GetType());
                target.InjectFrom(source);
                return target;
            }
            throw new exception.....
        }
        public static T InjectTo<T>(this T source, ref T target)
        {
            if (target == null)
            {
                target = source.InjectClone();
            }
            else
            {
                target.InjectFrom(source);
            }
            return source;
        }
