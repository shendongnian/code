    public static class CustomRequestScope
    {
        public static Ninject.Syntax.IBindingNamedWithOrOnSyntax<T> InCustomRequestScope<T>(this Ninject.Syntax.IBindingInSyntax<T> syntax)
        {
            return syntax.InScope(ctx => HttpContext.Current.Handler == null ? null : HttpContext.Current.Request);
        }
    }
