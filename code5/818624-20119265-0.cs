    <Window x:Class="WpfApplication7.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:system="clr-namespace:System;assembly=mscorlib"
        xmlns:collections="clr-namespace:System.Collections;assembly=mscorlib"
        Title="MainWindow" Height="350" Width="525">
    <Window.Resources>
        <collections:ArrayList  x:Key="StringArray">
            <system:String>Hei</system:String>
            <system:String>Hei</system:String>
            <system:String>Hei</system:String>
            <system:String>Hei</system:String>
        </collections:ArrayList>
    </Window.Resources>
    <Grid>
        <ListBox x:Name="filtersListBox" Grid.Row="1" 
         Background="Transparent" BorderThickness="0"
         ItemsSource="{StaticResource StringArray}">
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListBoxItem">
                                <Border CornerRadius="8" BorderThickness="0" BorderBrush="Orange" 
                        Margin="2" Background="Transparent" Name="itemBorder"
                        Width="275" VerticalAlignment="Center"
                        FocusManager.IsFocusScope="True" Focusable="True">
                                    <Border.Effect>
                                        <DropShadowEffect BlurRadius="1" ShadowDepth="2" Color="DarkOrange" Opacity="0.3"/>
                                    </Border.Effect>
                                    <ContentPresenter />
                                </Border>
                                        <ControlTemplate.Triggers>
                                            <Trigger Property="IsSelected" Value="True">
                                                <Setter TargetName="itemBorder" Property="Background" Value="Blue"></Setter>
                                            </Trigger>
                                        </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                    <Style.Resources>
                        <SolidColorBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" Color="Transparent"/>
                        <SolidColorBrush x:Key="{x:Static SystemColors.ControlBrushKey}" Color="Transparent"/>
                    </Style.Resources>
                </Style>
            </ListBox.ItemContainerStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid HorizontalAlignment="Center">
                        <Border CornerRadius="8" BorderThickness="0" BorderBrush="Orange" 
                        Margin="2" Background="Transparent" Name="itemBorder"
                        Width="275" VerticalAlignment="Center"
                        FocusManager.IsFocusScope="True" Focusable="True">
                            <Border.Effect>
                                <DropShadowEffect BlurRadius="1" ShadowDepth="2" Color="DarkOrange" Opacity="0.3"/>
                            </Border.Effect>
                            <Border.Style>
                                <Style TargetType="Border">
                                    <Style.Triggers>
                                        <Trigger Property="UIElement.IsFocused" Value="True">
                                            <Setter Property="Background" Value="Blue"/>
                                        </Trigger>
                                        <EventTrigger RoutedEvent="Border.MouseEnter">
                                            <BeginStoryboard>
                                                <Storyboard>
                                                    <ThicknessAnimation Duration="0:0:0.25"
                                                                To="2"
                                                                Storyboard.TargetProperty="BorderThickness"/>
                                                </Storyboard>
                                            </BeginStoryboard>
                                        </EventTrigger>
                                        <EventTrigger RoutedEvent="Border.MouseLeave">
                                            <BeginStoryboard>
                                                <Storyboard>
                                                    <ThicknessAnimation Duration="0:0:0.25"
                                                                To="0"
                                                                Storyboard.TargetProperty="BorderThickness"/>
                                                </Storyboard>
                                            </BeginStoryboard>
                                        </EventTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Border.Style>
                            <TextBlock Text="{Binding }" Margin="10, 2"/>
                        </Border>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
