      public object ReturnExceptionHandler(object bindingExpression, Exception exception)
      {
         BindingExpression be = bindingExpression as BindingExpression;
         var boundItem = be.DataItem;
         ((Wrapper.NotifyPropertyChanged)boundItem).Errors.Add(be.ResolvedSourcePropertyName, exception.Message);
         return exception.Message;
      }
