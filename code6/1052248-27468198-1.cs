    <Style TargetType="local:ExtendedListView">
        <Setter Property="IsTabStop"
                Value="False" />
        <Setter Property="TabNavigation"
                Value="Once" />
        <Setter Property="IsSwipeEnabled"
                Value="True" />
        <Setter Property="ScrollViewer.HorizontalScrollBarVisibility"
                Value="Disabled" />
        <Setter Property="ScrollViewer.VerticalScrollBarVisibility"
                Value="Auto" />
        <Setter Property="ScrollViewer.HorizontalScrollMode"
                Value="Disabled" />
        <Setter Property="ScrollViewer.IsHorizontalRailEnabled"
                Value="False" />
        <Setter Property="ScrollViewer.VerticalScrollMode"
                Value="Enabled" />
        <Setter Property="ScrollViewer.IsVerticalRailEnabled"
                Value="False" />
        <Setter Property="ScrollViewer.ZoomMode"
                Value="Disabled" />
        <Setter Property="ScrollViewer.IsDeferredScrollingEnabled"
                Value="False" />
        <Setter Property="ScrollViewer.BringIntoViewOnFocusChange"
                Value="True" />
        <Setter Property="ItemContainerTransitions">
            <Setter.Value>
                <TransitionCollection>
                    <AddDeleteThemeTransition />
                    <ContentThemeTransition />
                    <ReorderThemeTransition />
                    <EntranceThemeTransition IsStaggeringEnabled="False" />
                </TransitionCollection>
            </Setter.Value>
        </Setter>
        <Setter Property="ItemsPanel">
            <Setter.Value>
                <ItemsPanelTemplate>
                    <ItemsStackPanel Orientation="Vertical" />
                </ItemsPanelTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="ItemTemplate">
            <Setter.Value>
                <DataTemplate>
                    <!-- Put your custom DataTemplate here -->
                </DataTemplate>
            </Setter.Value>
        </Setter>
        <Setter Property="Template">
            <Setter.Value>
                <ControlTemplate TargetType="local:ExtendedListView">
                    <Border BorderBrush="{TemplateBinding BorderBrush}"
                            Background="{TemplateBinding Background}"
                            BorderThickness="{TemplateBinding BorderThickness}">
                        <ScrollViewer x:Name="ScrollViewer"
                                      TabNavigation="{TemplateBinding TabNavigation}"
                                      HorizontalScrollMode="{TemplateBinding ScrollViewer.HorizontalScrollMode}"
                                      HorizontalScrollBarVisibility="{TemplateBinding ScrollViewer.HorizontalScrollBarVisibility}"
                                      IsHorizontalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsHorizontalScrollChainingEnabled}"
                                      VerticalScrollMode="{TemplateBinding ScrollViewer.VerticalScrollMode}"
                                      VerticalScrollBarVisibility="{TemplateBinding ScrollViewer.VerticalScrollBarVisibility}"
                                      IsVerticalScrollChainingEnabled="{TemplateBinding ScrollViewer.IsVerticalScrollChainingEnabled}"
                                      IsHorizontalRailEnabled="{TemplateBinding ScrollViewer.IsHorizontalRailEnabled}"
                                      IsVerticalRailEnabled="{TemplateBinding ScrollViewer.IsVerticalRailEnabled}"
                                      ZoomMode="{TemplateBinding ScrollViewer.ZoomMode}"
                                      IsDeferredScrollingEnabled="{TemplateBinding ScrollViewer.IsDeferredScrollingEnabled}"
                                      BringIntoViewOnFocusChange="{TemplateBinding ScrollViewer.BringIntoViewOnFocusChange}"
                                      AutomationProperties.AccessibilityView="Raw">
                            <ItemsPresenter Header="{TemplateBinding Header}"
                                            HeaderTemplate="{TemplateBinding HeaderTemplate}"
                                            HeaderTransitions="{TemplateBinding HeaderTransitions}"
                                            Footer="{TemplateBinding Footer}"
                                            FooterTemplate="{TemplateBinding FooterTemplate}"
                                            FooterTransitions="{TemplateBinding FooterTransitions}"
                                            Padding="{TemplateBinding Padding}" />
                        </ScrollViewer>
                    </Border>
                </ControlTemplate>
            </Setter.Value>
        </Setter>
    </Style>
