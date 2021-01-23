     Application.Current.Resources.MergedDictionaries
                .Add(new ResourceDictionary
                {
                    Source = new Uri(@"pack://application:,,,/My.Application;component/Resources/Resources.xaml")
                });
