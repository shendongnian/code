        public ObservableCollection<HotkeyModel> Hotkeys { get; private set; }
        public class HotkeyWindow : Window
        {
            HotKeys = new ObservableCollection<HotkeyModel>();
            HotKeys.CollectionChanged += new NotifyCollectionChangedEventHandler(HotkeysChanged);
        }
        void HotkeysChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if(e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach(HotkeyModel hk in e.NewItems)
                    this.InputBindings.Add(new InputBinding(hk.Command), new KeyGesture(hk.Key, hk.Modifier));
            }
            else if(e. Action == NotifyCollectionChangedAction.Remove)
                ...
        }
