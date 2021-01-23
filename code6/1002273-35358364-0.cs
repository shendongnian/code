     <Window x:Class="WPFSO.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:wpfso="clr-namespace:WPFSO"        
                Title="MainWindow" Height="150" Width="525">
            <Window.DataContext>
                <wpfso:SharedSizeScopeViewModel />
            </Window.DataContext>
            <Window.Resources>
                <DataTemplate DataType="{x:Type wpfso:TestViewModel}">
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" x:Name="SecondColumn" />
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" x:Name="FourthColumn" />
                        </Grid.ColumnDefinitions>
        
                        <TextBlock Grid.Column="0" Text="{Binding Name}" />
                        <TextBlock Grid.Column="1" Background="LightGray" Text="{Binding Name2}"/>                
                        <TextBlock Grid.Column="2" Text="{Binding Name3}"/>
                        <TextBlock Grid.Column="3" Background="Orange" Text="{Binding Name4}"/>
                        
                        <!--<TextBlock Grid.Column="1" Background="Blue" HorizontalAlignment="Stretch" />
                        <TextBlock Grid.Column="3" Background="Orange" HorizontalAlignment="Stretch" />-->
                    </Grid>
                </DataTemplate>
        
                <DataTemplate x:Key="MainDataTemplate" DataType="wpfso:SharedSizeScopeViewModel" >
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" />
                            <ColumnDefinition Width="Auto" />
                            <ColumnDefinition Width="*" />
                        </Grid.ColumnDefinitions>
                        <Grid.RowDefinitions>
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                            <RowDefinition Height="Auto" />
                        </Grid.RowDefinitions>
        
                        <CheckBox Grid.Row="0" Grid.ColumnSpan="4" HorizontalAlignment="Left" FlowDirection="RightToLeft" Margin="0,0,0,25">
                            <TextBlock FlowDirection="LeftToRight" Text="Show differences" Style="{StaticResource LabelStyle}" />
                        </CheckBox>
        
                        <TextBlock Grid.Row="1" Grid.Column="0" Text="PropertyName" Style="{StaticResource LabelStyle}" />
                        <TextBlock Grid.Row="1" Grid.Column="1" Text="Previous value" Style="{StaticResource LabelStyle}" />
                        <TextBlock Grid.Row="1" Grid.Column="3" Text="Current value" Style="{StaticResource LabelStyle}" />
        
                        <ListView Grid.Row="2" Grid.Column="0" Grid.ColumnSpan="4"  ItemsSource="{Binding Entries}" HorizontalAlignment="Stretch" Margin="0" HorizontalContentAlignment="Stretch"/>
                    </Grid>
                </DataTemplate>
            </Window.Resources>
            <Grid Name="RootGrid">
        
               <ItemsControl ItemsSource="{Binding Entries}" />
               <!--<ListView ItemsSource="{Binding Entries}" />-->
        
            </Grid>
        </Window>
    
    The ViewModels used during this test:
    
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    
    namespace WPFSO
    {
        public class SharedSizeScopeViewModel : INotifyPropertyChanged
        {
    
            public SharedSizeScopeViewModel()
            {
                var testEntries = new ObservableCollection<TestViewModel>();
                
                testEntries.Add(new TestViewModel
                {
                    Name = "Test",
                    Name2 = "Looooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooong test",
                    Name3 = "Short test",
                    Name4 = "Nothing"
    
                    
                });
    
                Entries = testEntries;        
            }
    
            private ObservableCollection<TestViewModel> _entries;
    
            public ObservableCollection<TestViewModel> Entries
            {
                get { return _entries; }
                set
                {
                    _entries = value; 
                    OnPropertyChanged();
                }
            }
    
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
