     protected virtual bool AuthorizeCore(HttpContextBase httpContext)
     {
      if (httpContext == null)
        throw new ArgumentNullException("httpContext");
      IPrincipal user = httpContext.User;
      return user.Identity.IsAuthenticated 
       && (this._usersSplit.Length <= 0 ||
         Enumerable.Contains<string>((IEnumerable<string>) this._usersSplit, user.Identity.Name, (IEqualityComparer<string>) StringComparer.OrdinalIgnoreCase)) 
       && (this._rolesSplit.Length <= 0 || Enumerable.Any<string>((IEnumerable<string>) 
         this._rolesSplit, new Func<string, bool>(user.IsInRole)));
      }
