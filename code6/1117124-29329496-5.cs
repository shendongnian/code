    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    
    namespace Behaviors
    {
       public static class TextBoxScrollToEndBehavior
       {
          private static bool _isActive = false;
          public static bool IsActive
          {
             get
             {
                return _isActive;
             }
             set
             {
                _isActive = value;
             }
          }
    
    
    
    
          public static readonly DependencyProperty ScrollToEndOnEnabledBehavior = 
             DependencyProperty.RegisterAttached( "ScrollToEndOnEnabledBehavior",
                                                  typeof( bool ),
                                                  typeof( TextBoxScrollToEndBehavior ),
                                                  new UIPropertyMetadata( false, OnScrollToEndOnEnabledBehavior ) );
    
    
    
    
          public static bool GetScrollToEndOnEnabledBehavior( DependencyObject obj )
          {
             return (bool)obj.GetValue( ScrollToEndOnEnabledBehavior );
          }
    
    
    
    
          public static void SetScrollToEndOnEnabledBehavior( DependencyObject obj, bool value )
          {
             obj.SetValue( ScrollToEndOnEnabledBehavior, value );
          }
    
    
    
    
          private static void OnScrollToEndOnEnabledBehavior( object sender, DependencyPropertyChangedEventArgs e )
          {
             TextBox textBox = sender as TextBox;
             if( textBox != null )
             {
                bool isEnabled = (bool)e.NewValue;
                if( isEnabled )
                {
                   textBox.TextChanged += OnTextChanged_textBox;
                }
                else
                {
                   textBox.TextChanged -= OnTextChanged_textBox;
                }
             }
          }
    
    
    
    
          static void OnTextChanged_textBox( object sender, TextChangedEventArgs e )
          {
             TextBox textBox = sender as TextBox;
             if( null != textBox )
             {
                if( IsActive )
                {
                   if( textBox.IsFocused )
                   {
                      EditingCommands.MoveToLineEnd.Execute( null, textBox );
                   }
                   else
                   {
                      textBox.ScrollToHorizontalOffset( double.PositiveInfinity );
                   }
                }
             }
          }
       }
    }
