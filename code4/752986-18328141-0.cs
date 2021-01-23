     public static Status ExecuteRequests(params Func<Result>[] actions){
      foreach (Func<Result> action in actions) {
        Result r = action();
        if (!r.Success) {
          Status s = new Status() { Failed = action.Target.GetType().ToString() };
          return s;
        }
      }
      return new Status() { Success = true };
    }
