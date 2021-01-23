       /// <summary>
      /// Pointcut definition for Amendments that are targeted to Methods that have a declaring Attribute defined.
    /// </summary>
    abstract class MethodAmendment<TType, TDeclaringAttribute> : Amendment<TType, TType>
        where TDeclaringAttribute : Attribute
    {
        public MethodAmendment()
        {
            foreach (Method method in Methods)
            {
                //todo ?? look for base class versions of method ? should be covered by afterthought itself ?
                TDeclaringAttribute attribute = method.Attributes.OfType<TDeclaringAttribute>().FirstOrDefault();
                if (attribute != null)
                {
                    ApplyMethodChanges(method, attribute);
                }
            }
        }
        protected abstract void ApplyMethodChanges(Method method, TDeclaringAttribute attribute);
    }
