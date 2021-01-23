XAML
    <Window x:Class="CustomCheckBoxHelp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:local="clr-namespace:CustomCheckBoxHelp"
        xmlns:sys="clr-namespace:System;assembly=mscorlib"
        WindowStartupLocation="CenterScreen"
        Title="MainWindow" Height="350" Width="525">
    
    <Window.Resources>
        <sys:String x:Key="Up">
            F1 M 37.8516,35.625L 34.6849,38.7917L 23.6016,50.2708L 
            23.6016,39.9792L 37.8516,24.9375L 52.1016,39.9792L 52.1016,
            50.2708L 41.0182,38.7917L 37.8516,35.625 Z
        </sys:String>
        <sys:String x:Key="Down">
            F1 M 37.8516,39.5833L 52.1016,24.9375L 52.1016,35.2292L 
            37.8516,50.2708L 23.6016,35.2292L 23.6016,24.9375L 37.8516,39.5833 Z
        </sys:String>
        <Style x:Key="styleCustomCheckBox" TargetType="{x:Type CheckBox}">
            <Setter Property="FontFamily" Value="Verdana" />
            <Setter Property="FontSize" Value="14" />
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="{x:Type CheckBox}">
                        <StackPanel Orientation="Horizontal">
                            <Path x:Name="MyPin" Width="18" Height="18" Stretch="Fill" Fill="#FF000000" 
                                  Data="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=(local:CustomCheckBoxClass.IsCheckedOnData)}" />
                            <ContentPresenter VerticalAlignment="Center" Margin="10,0,0,0" />
                        </StackPanel>
                        <ControlTemplate.Triggers>
                            <Trigger Property="IsChecked" Value="False">
                                <Setter TargetName="MyPin" Property="Data"
                                        Value="{Binding RelativeSource={RelativeSource TemplatedParent}, Path=(local:CustomCheckBoxClass.IsCheckedOffData)}" />
                                <Setter TargetName="MyPin" Property="Fill" Value="Gray" />
                            </Trigger>
                        </ControlTemplate.Triggers>
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    
    <Grid>
        <StackPanel Orientation="Vertical" HorizontalAlignment="Center" Background="Beige">
            <CheckBox Height="35" 
                      local:CustomCheckBoxClass.IsCheckedOnData="{StaticResource Up}"
                      local:CustomCheckBoxClass.IsCheckedOffData="{StaticResource Down}"
                      Style="{StaticResource styleCustomCheckBox}" 
                      Content="MySolution1" />
            <CheckBox Height="35" 
                      local:CustomCheckBoxClass.IsCheckedOnData="{StaticResource Up}"
                      local:CustomCheckBoxClass.IsCheckedOffData="{StaticResource Down}"
                      Style="{StaticResource styleCustomCheckBox}" 
                      Content="MySolution2" />
        </StackPanel>
    </Grid>
    </Window>
Code behind
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }
    }
    public class CustomCheckBoxClass : DependencyObject
    {
        #region IsCheckedOnDataProperty
        public static readonly DependencyProperty IsCheckedOnDataProperty;
        public static void SetIsCheckedOnData(DependencyObject DepObject, string value)
        {
            DepObject.SetValue(IsCheckedOnDataProperty, value);
        }
        public static string GetIsCheckedOnData(DependencyObject DepObject)
        {
            return (string)DepObject.GetValue(IsCheckedOnDataProperty);
        }
        #endregion
        #region IsCheckedOffDataProperty
        public static readonly DependencyProperty IsCheckedOffDataProperty;
        public static void SetIsCheckedOffData(DependencyObject DepObject, string value)
        {
            DepObject.SetValue(IsCheckedOffDataProperty, value);
        }
        public static string GetIsCheckedOffData(DependencyObject DepObject)
        {
            return (string)DepObject.GetValue(IsCheckedOffDataProperty);
        }
        #endregion
        static CustomCheckBoxClass()
        {
            PropertyMetadata MyPropertyMetadata = new PropertyMetadata(string.Empty);
            IsCheckedOnDataProperty = DependencyProperty.RegisterAttached("IsCheckedOnData",
                                                                typeof(string),
                                                                typeof(CustomCheckBoxClass),
                                                                MyPropertyMetadata);
            IsCheckedOffDataProperty = DependencyProperty.RegisterAttached("IsCheckedOffData",
                                                                typeof(string),
                                                                typeof(CustomCheckBoxClass),
                                                                MyPropertyMetadata);
        }        
    }
