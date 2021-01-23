    public class TabOnEnterBehavior : Behavior<TextBox>
    {
      protected override void OnAttached()
      {
        AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
      }
      private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
      {
        if (e.Key == Key.Enter)
        {
          var request = new TraversalRequest(FocusNavigationDirection.Next);
          request.Wrapped = true;
          AssociatedObject.MoveFocus(request);
        }
      }
      protected override void OnDetaching()
      {
        AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
      }
    }
