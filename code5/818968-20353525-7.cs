        public TypedConstructorArgument(Type argumentType, object argumentValue)
            : this(argumentType, argumentValue, false)
        {
        }
        public TypedConstructorArgument(Type argumentType, object argumentValue, bool shouldInherit)
        {
            Ensure.ArgumentAssignableFrom(argumentType, argumentValue, "argumentValue");
            this.ArgumentType = argumentType;
            this.ArgumentValue = argumentValue;
            this.ShouldInherit = shouldInherit;
            this.Name = argumentType.FullName;
        }
        public virtual string Name { get; private set; }
        public virtual bool ShouldInherit { get; private set; }
        public virtual Type ArgumentType { get; private set; }
        public virtual object ArgumentValue { get; private set; }
        public object GetValue(IContext context, ITarget target)
        {
            return this.ArgumentValue;
        }
        public bool AppliesToTarget(IContext context, ITarget target)
        {
            return this.MatchesType(target.Type);
        }
        public override bool Equals(object obj)
        {
            var other = obj as IParameter;
            return other != null && this.Equals(other);
        }
        public override int GetHashCode()
        {
            return this.GetType().GetHashCode() ^ this.Name.GetHashCode();
        }
        public bool Equals(IParameter other)
        {
            return other.GetType() == this.GetType() && other.Name.Equals(this.Name);
        }
        public bool MatchesType(Type type)
        {
            return this.ArgumentType == type;
        }
    }
