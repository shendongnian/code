    <views:TabContent.Template>
        <DataTemplate>
            <Grid>
                ...
                    <DockPanel Grid.Column="0">
                        <ToolBarTray DockPanel.Dock="Left" Orientation="Vertical">
                            <ToolBar>
                                <Button Command="{Binding ElementName=tabControl, Path=DataContext.ShowAnotherWindow}" CommandParameter="{Binding }">
                                    <Image Source="{StaticResource GalleryPropertyImage}" />
                                </Button>
                            </ToolBar>
                        </ToolBarTray>
                    </DockPanel>
                ...
            </Grid>
        </DataTemplate>
    </views:TabContent.Template>
