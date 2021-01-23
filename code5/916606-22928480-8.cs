    <Page.Resources>
        <Style x:Name="MyFavoriteAppBar" TargetType="ContentControl">
            <Setter Property="Template">
                <Setter.Value>
                    <ControlTemplate TargetType="ContentControl">
                        <AppBar ... />
                    </ControlTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Page.Resources>
    <Grid>
        <Page.TopAppBar>
            <ContentControl Style="{StaticResource MyFavoriteAppBar}" />
        </Page.TopAppBar>
        <Page.BottomAppBar>
            <ContentControl Style="{StaticResource MyFavoriteAppBar}" />
        </Page.BottomAppBar>
    </Grid>
