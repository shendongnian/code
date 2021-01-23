    <Menu DockPanel.Dock="Top" ItemsSource="{Binding Path=MainMenu}">
        <Menu.ItemContainerStyle>
            <Style>
                <Setter Property="MenuItem.Header" Value="{Binding Path=Header}" />
                <Setter Property="MenuItem.ItemsSource" Value="{Binding Path=Items}" />
                <Setter Property="MenuItem.Icon" Value="{Binding Path=Icon}" />
                <Setter Property="MenuItem.IsCheckable" Value="{Binding Path=IsCheckable}" />
                <Setter Property="MenuItem.IsChecked" Value="{Binding Path=IsChecked,Mode=TwoWay,UpdateSourceTrigger=PropertyChanged}" />
                <Setter Property="MenuItem.Command" Value="{Binding Path=Command}" />
                <!--<Setter Property="MenuItem.CommandParameter" Value="{Binding Path=IsChecked}"/>-->
                <Setter Property="MenuItem.CommandParameter" Value="{Binding Path=.}"/>
                <Setter Property="MenuItem.InputGestureText" Value="{Binding Path=InputGestureText}"/>
                <Setter Property="MenuItem.ToolTip" Value="{Binding Path=ToolTip}" />
                <Style.Triggers>
                    <DataTrigger Binding="{Binding Path=IsSeparator}" Value="true">
                        <Setter Property="MenuItem.Template">
                            <Setter.Value>
                                <ControlTemplate TargetType="{x:Type MenuItem}">
                                    <Separator Style="{DynamicResource {x:Static MenuItem.SeparatorStyleKey}}" />
                                </ControlTemplate>
                            </Setter.Value>
                        </Setter>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </Menu.ItemContainerStyle>
    </Menu>
