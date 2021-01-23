       <Window.Template>
        <ControlTemplate>
            <Grid>
                <Grid.RowDefinitions>
                    <RowDefinition Height="20"/>
                    <RowDefinition Height="*" />
                </Grid.RowDefinitions>
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="*" />
                    <ColumnDefinition Width="100" />
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Row="0" Grid.Column="0">
                    <Hyperlink NavigateUri="http://mysite.com">
                        My Program, version 1
                    </Hyperlink>
                </TextBlock>
                
                <ContentPresenter />
            </Grid>
        </ControlTemplate>
    </Window.Template>
