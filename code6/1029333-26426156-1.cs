        public bool ClassNamesEqual(IClassNameAware otherClass)
        {
            return GetClassName().Equals(otherClass.GetClassName());
        }
    }
