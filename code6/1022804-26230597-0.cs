     <ListView.ItemContainerStyle>
        <Style TargetType="ListViewItem">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ListViewItem">
                        <Grid Background="Yellow">
                            <VisualStateManager.VisualStateGroups>
                                <VisualStateGroup x:Name="CommonStates">
                                    <VisualState x:Name="Normal"/>
                                </VisualStateGroup>
                                <VisualStateGroup x:Name="SelectionStates">
                                    <VisualState x:Name="Unselected">
                                        <Storyboard>
                                            <ColorAnimation Duration="0" Storyboard.TargetName="myback" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)" To="White"/>
                                        </Storyboard>
                                    </VisualState>
                                    <VisualState x:Name="SelectedUnfocused">
                                        <Storyboard>
                                            <ColorAnimation Duration="0" Storyboard.TargetName="myback" Storyboard.TargetProperty="(Border.Background).(SolidColorBrush.Color)" To="LightBlue"/>
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
