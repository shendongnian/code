    <ContentControl>
                    <ContentControl.Style>
                        <Style TargetType="{x:Type ContentControl}">
                        <Style.Triggers>
                                <DataTrigger Binding="{Binding Path=IsOnline}" Value="True">
                                <Setter Property="Content" >
                                    <Setter.Value>
                                        <Rectangle Fill="Green" Width="20" Height="20">
                                            <Rectangle.Resources>
                                                <SolidColorBrush x:Key="BlackBrush" Color="Black" />
                                            </Rectangle.Resources>
                                            <Rectangle.OpacityMask>
                                                <VisualBrush Visual="{StaticResource appbar_disconnect}" Stretch="Fill" />
                                            </Rectangle.OpacityMask>
                                        </Rectangle>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                                <DataTrigger Binding="{Binding Path=IsOnline}" Value="False">
                                <Setter Property="Content" >
                                    <Setter.Value>
                                        <Rectangle Fill="Red" Width="20" Height="20">
                                            <Rectangle.Resources>
                                                <SolidColorBrush x:Key="BlackBrush" Color="Black" />
                                            </Rectangle.Resources>
                                            <Rectangle.OpacityMask>
                                                <VisualBrush Visual="{StaticResource appbar_connect}" Stretch="Fill" />
                                            </Rectangle.OpacityMask>
                                        </Rectangle>
                                    </Setter.Value>
                                </Setter>
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </ContentControl.Style>
                </ContentControl>
