    <ResourceDictionary
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="clr-namespace:TestAttachedPropertyValidationError">
    <Style TargetType="{x:Type local:TextBoxCustomControl}">
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="{x:Type local:TextBoxCustomControl}">
                    <Border Background="{TemplateBinding Background}"
                            BorderBrush="{TemplateBinding BorderBrush}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                        <Grid>
                            <Grid.RowDefinitions>
                                <RowDefinition Height="Auto"/>
                                <RowDefinition Height="Auto"/>
                                <RowDefinition Height="Auto"/>
                            </Grid.RowDefinitions>
                            <Grid.ColumnDefinitions>
                                <ColumnDefinition Width="Auto"/>
                                <ColumnDefinition Width="10"/>
                                <ColumnDefinition Width="50"/>
                            </Grid.ColumnDefinitions>
                            <Grid.Resources>
                                <BooleanToVisibilityConverter x:Key="BooleanToVisibilityConverter"/>
                            </Grid.Resources>
                            <Label 
                                Grid.Row ="0" 
                                Grid.Column="0" 
                                Content="Enter a numeric value:" />
                            <TextBox 
                                Grid.Row ="0" 
                                Grid.Column="2" 
                                local:HasErrorUtility.HasError="{Binding NumericPropHasError, Mode=TwoWay, RelativeSource={RelativeSource TemplatedParent}}"
                                Text="{Binding NumericProp, Mode=TwoWay, UpdateSourceTrigger=LostFocus, RelativeSource={RelativeSource TemplatedParent}}" />
                            <Label 
                                Grid.Row ="1" 
                                Grid.Column="0" 
                                Content="Value entered:" />
                            <Label 
                                Grid.Row ="1" 
                                Grid.Column="2" 
                                Content="{TemplateBinding NumericProp}" />
                            <Label 
                                Grid.Row ="2" 
                                Grid.Column="0" 
                                Grid.ColumnSpan="3" 
                                Visibility="{TemplateBinding NumericPropHasError, Converter={StaticResource BooleanToVisibilityConverter}}"
                                Foreground="Red" 
                                Content="Not a numeric value" />
                        </Grid>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
