    <TabControl ItemsSource="{Binding Path=TabItems, Mode=OneTime}" SelectedValue="{Binding Path=SelectedTab, Mode=TwoWay}">
        <TabControl.ItemContainerStyle>
            <Style TargetType="TabItem">
                <Setter Property="Header" Value="{Binding Header}"/>
                <Setter Property="Content" Value="{Binding}"/>
                <Setter Property="Template">
                    <Setter.Value>
                        <ControlTemplate TargetType="{x:Type TabItem}">
                            <Grid>
                                <Border Name="Border" Margin="0,0,-4,0" BorderThickness="1">
                                    <ContentPresenter
                                        x:Name="ContentSite"
                                        HorizontalAlignment="Center"
                                        Margin="12,2,12,2"
                                        VerticalAlignment="Center"
                                        ContentSource="Header"
                                        RecognizesAccessKey="True"/>
                                </Border>
                            </Grid>
                            <ControlTemplate.Triggers>
                                <Trigger Property="IsSelected" Value="True">
                                            etc...
                                        
                                </Trigger>
                                <Trigger Property="IsMouseOver" Value="True">
                                            etc...
                                        
                                </Trigger>
                            </ControlTemplate.Triggers>
                        </ControlTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </TabControl.ItemContainerStyle>
    </TabControl>
