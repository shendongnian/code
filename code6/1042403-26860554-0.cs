      <ListView>
        <ListViewItem Content="asdasd"/>
        <ListViewItem Content="asdasd"/>
        <ListViewItem Content="asdasd"/>
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Style.Setters>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type ListViewItem}">
                                <ControlTemplate.Resources>
                                    <Style x:Key="ListViewItemBorderStyle" TargetType="{x:Type Border}">
                                        <Setter Property="Background" Value="Red"/>
                                        <Setter Property="BorderBrush" Value="#5076A7" />
                                        <Setter Property="BorderThickness" Value="1" />
                                        <Setter Property="CornerRadius" Value="4" />
                                    </Style>
                                </ControlTemplate.Resources>
                                <Border Height="100" Style="{StaticResource ListViewItemBorderStyle}">
                                 <!--....-->
                                </Border>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style.Setters>
            </Style>
        </ListView.ItemContainerStyle>
    </ListView>
     
