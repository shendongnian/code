        <ListView x:Name="mylistview">
            <ListView.ItemContainerStyle>
                <Style TargetType="ListViewItem">                    
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListViewItem">                                
                                <Grid>
                                    <VisualStateManager.VisualStateGroups>
                                        <VisualStateGroup x:Name="CommonStates">
                                            <VisualState x:Name="Normal"/>
                                        </VisualStateGroup>
                                        <VisualStateGroup x:Name="SelectionStates">
                                            <VisualState x:Name="Unselected">
                                                <Storyboard>
                                                    <ColorAnimation Duration="0" Storyboard.TargetName="myback" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)" To="Transparent"/>
                                                </Storyboard>
                                            </VisualState>
                                            <VisualState x:Name="SelectedUnfocused">                                                
                                                <Storyboard>
                                                    <ColorAnimation Duration="0" Storyboard.TargetName="myback" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)" To="Red"/>
                                                </Storyboard>
                                            </VisualState>
                                        </VisualStateGroup>
                                    </VisualStateManager.VisualStateGroups>
                                    <Border x:Name="myback" Background="Transparent">
                                        <ContentPresenter Content="{TemplateBinding Content}" ContentTemplate="{TemplateBinding ContentTemplate}"/>
                                    </Border>
                                </Grid>                                
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListView.ItemContainerStyle>
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Height="100">
                    <TextBlock Text="{Binding Artist}" FontSize="22"/>
                    <TextBlock Text="{Binding Song}" FontSize="22"/>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>        
