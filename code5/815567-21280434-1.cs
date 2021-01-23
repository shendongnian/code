    using System;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Interactivity;
    namespace MyApp.Extensions
    {
    /// <summary>
    /// Custom behavior that updates the source of a binding on a text box as the text changes.
    /// </summary>
    public class UpdateTextBindingOnPropertyChanged : Behavior<TextBox>
    {
      private BindingExpression _expression;
      /// <summary>
      /// Called after the behavior is attached to an AssociatedObject.
      /// </summary>
      /// <remarks>
      /// Override this to hook up functionality to the AssociatedObject.
      /// </remarks>
      protected override void OnAttached()
      {
        base.OnAttached();
        _expression = AssociatedObject.GetBindingExpression(TextBox.TextProperty);
        AssociatedObject.TextChanged += new TextChangedEventHandler(this.OnTextChanged);
      }
      /// <summary>
      /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
      /// </summary>
      /// <remarks>
      /// Override this to unhook functionality from the AssociatedObject.
      /// </remarks>
      protected override void OnDetaching()
      {
        base.OnDetaching();
        AssociatedObject.TextChanged -= new TextChangedEventHandler(this.OnTextChanged);
        _expression = (BindingExpression) null;
      }
      private void OnTextChanged(object sender, EventArgs args)
      {
        _expression.UpdateSource();
      }
    }
    }
