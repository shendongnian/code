    public string DataPath
        {
            get { return (string)GetValue(DataPathProperty); }
            set { SetValue(DataPathProperty, value); }
        }
        // Using a DependencyProperty as the backing store for DataPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DataPathProperty =
            DependencyProperty.Register("DataPath", typeof(string), typeof(ownerclass), new PropertyMetadata(0));
    <Path x:Name="MyPath" Data="{Binding Path=DataPath, ElementName='yourControlname'}" Fill="#FF2764BB" HorizontalAlignment="Left" Height="24.833" Margin="0.073,-0.04,0,0" Stretch="Fill" VerticalAlignment="Top" Width="65.892"/>
