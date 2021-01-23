      public void TopMenuAsync()
      {
          AsyncManager.OutstandingOperations.Increment();
          Task.Run<IEnumerable<TopMenuItem>>(() => { return _menuService.GetTopMenu(); })
              .ContinueWith(t =>
              {
                  AsyncManager.Parameters["topMenu"] = t.Result;
                  AsyncManager.OutstandingOperations.Decrement();
              });
      }
      public ActionResult TopMenuCompleted(TopMenuItem topMenu)
      {
          //view model population code goes here
          return PartialView(viewModel);
      }
