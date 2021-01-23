        <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition></ColumnDefinition>
            <ColumnDefinition></ColumnDefinition>
            <ColumnDefinition></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <!--****************************1st method*******************************-->
        <ListView x:Name="XListView" Grid.Column="0" ItemsSource="{Binding li}" >
            <ListView.Resources>
                <Style TargetType="ListViewItem">
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="ListViewItem">
                                <Grid Width="185" Height="85" Margin="20" Background="Red" Opacity="0.1">
                                    <TextBlock Text="TextData"/>
                                </Grid>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListView.Resources>
            <ListViewItem>ListviewItemData1</ListViewItem>
        </ListView>
        <!--**************************2nd method***********************************-->
        <ListView  Grid.Column="1" ItemsSource="{Binding li}" >
            <ListView.Resources>
                <Style TargetType="ListViewItem">
                    <Setter Property="ContentTemplate" >
                        <Setter.Value>
                            <DataTemplate>
                                <Grid Width="185" Height="85" Margin="20" Background="Red" Opacity="0.1">
                                    <TextBlock Text="TextData"/>
                                </Grid>
                            </DataTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
            </ListView.Resources>
            <ListViewItem>ListviewItemData1</ListViewItem>
        </ListView>
        <!--*****************3rd method*****************-->
        <ListView Grid.Column="2">
            <ListViewItem >
                <ListViewItem.Template>
                    <ControlTemplate TargetType="ListViewItem">
                        <Grid Width="185" Height="85" Margin="20" Background="Red" Opacity="0.1">
                            <TextBlock Text="TextData"/>
                        </Grid>
                    </ControlTemplate>
                </ListViewItem.Template>
            </ListViewItem>
        </ListView>
    </Grid>
