    public class MyMouseMoveEvenTrigger : EventTriggerBase<ListView>
    {
        public ModifierKeys Modifier
        {
            get { return (ModifierKeys) GetValue(ModifierProperty); }
            set { SetValue(ModifierProperty, value); }
        }
        public static readonly DependencyProperty ModifierProperty =
            DependencyProperty.Register("Modifier", typeof (ModifierKeys), typeof (MyMouseMoveEvenTrigger), new PropertyMetadata(ModifierKeys.None));
        public Key Key
        {
            get { return (Key) GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }
        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof (Key), typeof (MyMouseMoveEvenTrigger), new PropertyMetadata(Key.None));
        private bool _matchPredicate;
        private ListView ListView
        {
            get { return AssociatedObject as ListView; }
        }
        protected override void OnAttached()
        {
            Keyboard.AddPreviewKeyDownHandler(ListView, PreviewKeyDownHandler);
            Keyboard.AddKeyUpHandler(ListView, KeyUpHandler);
            
            base.OnAttached();
        }
        private void PreviewKeyDownHandler(object s, KeyEventArgs e)
        {
            var modifierOk = Equals(Modifier, DependencyProperty.UnsetValue) || Modifier == ModifierKeys.None || Keyboard.Modifiers == Modifier;
            var keyOk = Equals(Key, DependencyProperty.UnsetValue) || Key == Key.None || Keyboard.IsKeyDown(Key);
            _matchPredicate = modifierOk && keyOk;
            e.Handled = _matchPredicate;
            RefreshItems();
        }
        private void KeyUpHandler(object s, KeyEventArgs e)
        {
            _matchPredicate =
                (Equals(Modifier, DependencyProperty.UnsetValue) || Modifier == ModifierKeys.None)
                &&
                (Equals(Key, DependencyProperty.UnsetValue) || Key == Key.None);
            RefreshItems();
        }
        protected override void OnDetaching()
        {
            Keyboard.RemoveKeyDownHandler(ListView, PreviewKeyDownHandler);
            Keyboard.RemoveKeyUpHandler(ListView, KeyUpHandler);
            base.OnDetaching();
        }
        protected override void OnEvent(EventArgs eventArgs)
        {
            Keyboard.Focus(ListView);
            var modifierOk = Equals(Modifier, DependencyProperty.UnsetValue) || Modifier == ModifierKeys.None || Keyboard.Modifiers == Modifier;
            var keyOk = Equals(Key, DependencyProperty.UnsetValue) || Key == Key.None || Keyboard.IsKeyDown(Key);
            _matchPredicate = modifierOk && keyOk;
            RefreshItems();
        }
        private void RefreshItems()
        {
            foreach (ListViewItem lvi in ListView.Items)
            {
                lvi.Tag = _matchPredicate && lvi.IsMouseOver ? "Yes" : null;
            }
        }
        protected override string GetEventName()
        {
            return "MouseMove";
        }
    }
