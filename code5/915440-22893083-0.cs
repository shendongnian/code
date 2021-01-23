      public IOrderNotification _orderNotification;
      public IOrderNotification OrderNotification
            {
                get
                {
                    return _orderNotification ??
                           (_orderNotification = DependencyResolver.Current.GetService<IOrderNotification>());
                }
                set { _orderNotification = value; }
            }
