    public static DependencyProperty IsClosedProperty = DependencyProperty.Register("IsClosed", typeof(bool), typeof(GroupBox), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(OnIsClosedChangedPCC)));
    
            public bool IsClosed {
                get {
                    return (bool)this.GetValue(IsClosedProperty);
                }
                set {
                    this.SetValue(IsClosedProperty, value);
                    OnIsClosedChanged();
                }
            }
    
    
    
            private static void OnIsClosedChangedPCC(DependencyObject d, DependencyPropertyChangedEventArgs e) {
                GroupBox current = (GroupBox)d;
                current.IsClosed = current.IsClosed;
            }
    
    
    
            private void OnIsClosedChanged() {
                _rowDefContent.Height = new GridLength((IsClosed ? 0 : 1), GridUnitType.Star);
            }
