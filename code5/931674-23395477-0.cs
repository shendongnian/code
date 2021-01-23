    public class DesignMode : FrameworkElement
        {
            public static GAppLanguage GetDesignLanguage(DependencyObject obj)
            {
                return (GAppLanguage)obj.GetValue(DesignLanguageProperty);
            }
    
            public static void SetDesignLanguage(DependencyObject obj, GAppLanguage value)
            {
                obj.SetValue(DesignLanguageProperty, value);
            }
    
            public static readonly DependencyProperty DesignLanguageProperty =
                DependencyProperty.RegisterAttached("DesignLanguage", typeof(GAppLanguage), typeof(DesignMode), new PropertyMetadata(GAppLanguage.EN, new PropertyChangedCallback(DesingLanguageChanged)));
    
            private static void DesingLanguageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                DesignMode.DesignLanguage = (GAppLanguage) Enum.Parse(typeof(GAppLanguage),e.NewValue.ToString());
            }
    
            public static GAppLanguage DesignLanguage { get; set; }
        }
