    class SampleClass
    {
        public string ImageSource
        {
            get
            {
                if ((Visibility)App.Current.Resources["PhoneDarkThemeVisibility"] == Visibility.Visible)
                {
                    return "Dark";//You can set your Image here
    
                }
                else
                {
                    return "Light";//You can set your Image here
    
                }
            }
            private set { }
        }
    }
