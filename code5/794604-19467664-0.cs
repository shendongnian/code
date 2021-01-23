           <TabControlDataContext="{Binding Source={StaticResource SharedSettingsViewModel}}" ItemsSource="{Binding SharedSettingsViewModelsTabList}">
                <TabControl.ContentTemplate>
                       <DataTemplate>
                            <ContentPresenter Content="{Binding Content}"/>
                        </DataTemplate>
                </TabControl.ContentTemplate>
                <TabControl.ItemContainerStyle>
                    <Style TargetType="TabItem">
                        <Setter Property="Header" Value="{Binding Header}"/>
                    </Style>
                </TabControl.ItemContainerStyle>
            </TabControl>
