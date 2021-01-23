     <ItemsControl x:Name="MyItemControl" ItemsSource="{Binding ViewModelOne.Items}">
         <ItemsControl.ItemContainerStyle>
                    <Style TargetType="ContentPresenter">
                        <Setter Property="Tag" Value="{Binding DataContext, ElementName=MyItemControl}"></Setter>
                        <Setter Property="ContextMenu">
                            <Setter.Value>
                                <ContextMenu >
                                    <MenuItem Header="Delete" Command="{Binding PlacementTarget.Tag.ViewModelOne.DeleteCommand, RelativeSource={RelativeSource Self}}" />
                                </ContextMenu>
                            </Setter.Value>
                        </Setter>
                        <Setter Property="Canvas.Left" Value="{Binding X}"/>
                        <Setter Property="Canvas.Top" Value="{Binding Y}"/>
                    </Style>
                </ItemsControl.ItemContainerStyle>
