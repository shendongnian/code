    <ItemsControl regions:RegionManager.RegionName="{x:Static statics:ContentRegions.ContentCollection}">
                <ItemsControl.Template>
                    <ControlTemplate>
                        <ScrollViewer HorizontalScrollBarVisibility="Auto" VerticalScrollBarVisibility="Disabled">
                            <ItemsPresenter/>
                        </ScrollViewer>
                    </ControlTemplate>
                </ItemsControl.Template>
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Horizontal" />
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
            </ItemsControl>
