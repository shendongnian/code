    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    
    namespace Views.Styles
    {
        public class HighConstrastWhite : DependencyObject
        {
        #region Singleton pattern
    
            private HighConstrastWhite()
            {
                SystemParameters.StaticPropertyChanged += SystemParameters_StaticPropertyChanged;
            }
    
    
            private static HighConstrastWhite _instance;
    
    
            public static HighConstrastWhite Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new HighConstrastWhite();
    
                    return _instance;
                }
            }
    
        #endregion
    
        public void ApplyCurrentTheme()
        {  
            if(SystemParameters.HighContrast)
            {
                SolidColorBrush windowbrush = SystemColors.WindowBrush;
                if (windowbrush.Color.R == 255 && windowbrush.Color.G == 255 && windowbrush.Color.B == 255)
                    HighConstrastWhite.Instance.IsHighContrastWhite = true;
                else
                    HighConstrastWhite.Instance.IsHighContrastWhite = false;
            }
        }
    
        void SystemParameters_StaticPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //Console.WriteLine(e.PropertyName);
            if (e.PropertyName == "HighContrast")
            {
                ApplyCurrentTheme();
            }
            
        }
    
    
        #region DP IsHighContrast
    
        public static readonly DependencyProperty IsHighContrastWhiteProperty = DependencyProperty.Register(
            "IsHighContrastWhite",
            typeof(bool),
            typeof(HighConstrastWhite),
            new PropertyMetadata(
                false
                ));
    
    
        public bool IsHighContrastWhite
        {
            get { return (bool)GetValue(IsHighContrastWhiteProperty); }
            private set { SetValue(IsHighContrastWhiteProperty, value); }
        }
    
        #endregion
    
    }
    }
