    public static class Behaviours
    {
        #region ExpandingBehaviour (Attached DependencyProperty)
        public static readonly DependencyProperty ExpandingBehaviourProperty =
            DependencyProperty.RegisterAttached("ExpandingBehaviour", typeof(ICommand), typeof(Behaviours),
                new PropertyMetadata(OnExpandingBehaviourChanged));
        public static void SetExpandingBehaviour(DependencyObject o, ICommand value)
        {
            o.SetValue(ExpandingBehaviourProperty, value);
        }
        public static ICommand GetExpandingBehaviour(DependencyObject o)
        {
            return (ICommand) o.GetValue(ExpandingBehaviourProperty);
        }
        private static void OnExpandingBehaviourChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TreeViewItem tvi = d as TreeViewItem;
            if (tvi != null)
            {
                ICommand ic = e.NewValue as ICommand;
                if (ic != null)
                {
                    tvi.Expanded += (s, a) => 
                    {
                        if (ic.CanExecute(a))
                        {
                            ic.Execute(a);
                            
                        }
                        a.Handled = true;
                    };
                }
            }
        }
        #endregion
    }
