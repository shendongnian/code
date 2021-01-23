     <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="80*"></RowDefinition>
            <RowDefinition Height="20*"></RowDefinition>
        </Grid.RowDefinitions>
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="20*"></ColumnDefinition>
                <ColumnDefinition Width="80*"></ColumnDefinition>
            </Grid.ColumnDefinitions>
            <StackPanel Orientation="Vertical" Background="LightGray">
                <TextBlock FontSize="20" HorizontalAlignment="Center">Customer Details</TextBlock>
                <ListView ItemsSource="{Binding Details}"
                          SelectedItem="{Binding SelectedMenuItem, Mode=TwoWay}">
                    <ListView.ItemTemplate>
                        <DataTemplate>
                            <Grid>
                                <TextBlock Text="{Binding Name}" />
                            </Grid>
                        </DataTemplate>
                    </ListView.ItemTemplate>
                </ListView>
            </StackPanel>
           
            <FlipView Grid.Column="1" ItemTemplateSelector="{StaticResource MenuNameDataTemplateSelector}"
                      ItemsSource="{Binding Details, Mode=TwoWay}"
                      SelectedItem="{Binding SelectedMenuItem, Mode=TwoWay}">
                <FlipView.Resources>
                    <DataTemplate x:Key="Demographics">
                        <details:Demographics />
                    </DataTemplate>
                    <DataTemplate x:Key="Order History"></DataTemplate>
                    <DataTemplate x:Key="Communication Settings"></DataTemplate>
                    <DataTemplate x:Key="Alerts"></DataTemplate>
                    <DataTemplate x:Key="Order Product List">
                        <views:OrderProductList />
                    </DataTemplate>
                </FlipView.Resources>
            </FlipView>
           
            
        </Grid>
