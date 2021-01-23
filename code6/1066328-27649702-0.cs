    <Window.DataContext>
        <my:MainWindowViewModel />
    </Window.DataContext>
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="{Binding LeftGridWidth}" />
            <ColumnDefinition Width="{Binding RightGridWidth}" />
        </Grid.ColumnDefinitions>
        <Grid x:Name="LeftGrid" Grid.Column="0">
            <Image Source="Resources/DemoImage.jpg" Stretch="Fill">
                <i:Interaction.Triggers>
                    <i:EventTrigger EventName="MouseLeftButtonDown">
                        <i:InvokeCommandAction Command="{Binding ShowRightGridCommand}"/>
                    </i:EventTrigger>
                </i:Interaction.Triggers>
            </Image>
        </Grid>
        <Grid x:Name="RightGrid" Grid.Column="1">
            <StackPanel Orientation="Vertical">
                <Button>Something 1</Button>
                <Button>Something 2</Button>
                <Button>Something 3</Button>
            </StackPanel>
        </Grid>
    </Grid>
