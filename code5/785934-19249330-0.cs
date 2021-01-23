    <ListView ...>
            <ListView.ItemContainerStyle>
                <Style TargetType="{x:Type ListViewItem}">
                    <Style.Triggers>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="helpers:ListViewHelper.IsMouseDirectlyOverItem" Value="False"/>
                                <Condition Property="IsSelected" Value="False"/>
                                <Condition Property="IsFocused" Value="false"/>
                            </MultiTrigger.Conditions>
                            <Setter Property="Background" Value="Transparent"/>
                            <Setter Property="BorderBrush" Value="Transparent"/>
                            <Setter Property="BorderThickness" Value="0"/>
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="helpers:ListViewHelper.IsMouseDirectlyOverItem" Value="True"/>
                                <Condition Property="IsSelected" Value="False"/>
                            </MultiTrigger.Conditions>
                            <Setter Property="Background">
                                <Setter.Value>
                                    <LinearGradientBrush EndPoint="0,1" StartPoint="0,0">
                                        <GradientStop Color="#FFF8F8F8" Offset="0"/>
                                        <GradientStop Color="#FFE5E5E5" Offset="1"/>
                                    </LinearGradientBrush>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="BorderBrush" Value="#D9D9D9"/>
                            <Setter Property="BorderThickness" Value="1"/>
                        </MultiTrigger>
                        <MultiTrigger>
                            <MultiTrigger.Conditions>
                                <Condition Property="IsFocused" Value="True"/>
                                <Condition Property="IsSelected" Value="True"/>
                            </MultiTrigger.Conditions>
                            <Setter Property="Background">
                                <Setter.Value>
                                    <LinearGradientBrush EndPoint="0,1" StartPoint="0,0">
                                        <GradientStop Color="#FFFAFBFD" Offset="0"/>
                                        <GradientStop Color="#B8D6FB " Offset="1"/>
                                    </LinearGradientBrush>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="BorderBrush" Value="#D9D9D9"/>
                            <Setter Property="BorderThickness" Value="1"/>
                        </MultiTrigger>
                    </Style.Triggers>
                    <Style.Resources>
                        <Style TargetType="Border">
                            <Setter Property="CornerRadius" Value="2"/>
                        </Style>
                    </Style.Resources>
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.ItemTemplate>
                <DataTemplate>
                 ...   
                </DataTemplate>
            </ListView.ItemTemplate>
            <ListView.Resources>
                <!-- Brushes for the selected item -->
                <LinearGradientBrush x:Key="{x:Static SystemColors.HighlightBrushKey}" EndPoint="0,1" StartPoint="0,0">
                    <GradientStop Color="#FFFAFBFD" Offset="0"/>
                    <GradientStop Color="#B8D6FB " Offset="1"/>
                </LinearGradientBrush>
                <SolidColorBrush x:Key="{x:Static SystemColors.HighlightTextBrushKey}" Color="Black" />
                <SolidColorBrush x:Key="{x:Static SystemColors.ControlTextBrushKey}" Color="Black" />
            </ListView.Resources>
        </ListView>
