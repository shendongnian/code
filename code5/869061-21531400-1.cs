    class AnObjectThatWillSoonGoOutOfScope{
      public AnObjectThatWillSoonGoOutOfScope(ISomeLongLivedService service){
        service.SomeEvent += OnSomeEvent;
      }
      private void OnSomeEvent(...){...}
    }
