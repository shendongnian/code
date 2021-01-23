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
    ) where TObject : class
    where TResult: class {
       var maybeT = pObject as TObject;
       if (maybeT == null)
          return null;
       var t = maybeT;
     
       return pFunc(t);
    }
    // to allow for primitive return values
    public static TResult MaybeAs<TObject, TResult>(
       this object pObject,
       Func<TObject, TResult> pFunc,
       TResult pValueWhenNot
    ) where TObject : class {
       var maybeT = pObject as TObject;
       if (maybeT == null)
          return pValueWhenNot;
       var t = maybeT;
 
       return pFunc(t);
    }
