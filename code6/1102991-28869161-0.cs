    public static void MaybeAs<T>(
       this object pObject,
       Action<T> pAction
    ) {
       var maybeT = pObject as T;
       if (maybeT == null)
          return;
       var t = maybeT;
       pAction(t);
    }
    // and one for functions
    public static TResult MaybeAs<TObject, TResult>(
       this object pObject,
       Func<TObject, TResult> pFunc
    ) {
       var maybeT = pObject as TObject;
       if (maybeT == null)
          return;
       var t = maybeT;
     
       return pFunc(t);
    }
