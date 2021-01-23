        <Grid Style="{StaticResource TableHeader}">
            <Grid.Resources>
                <Style TargetType="{x:Type Border}" BasedOn="{StaticResource TableBorder}"/>
                <Style TargetType="{x:Type TextBlock}" BasedOn="{StaticResource TextTableHeader}">
                    <Setter Property="TextWrapping" Value="Wrap"/>
                </Style>
            </Grid.Resources>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Border BorderThickness="1">
                <TextBlock Text="Card"/>
            </Border>
            <Border Grid.Column="1" BorderThickness="0 1 1 1">
                <TextBlock Text="Type"/>
            </Border>
            <Border Grid.Column="2" BorderThickness="0 1 1 1">
                <TextBlock Text="Limit"/>
            </Border>
            <Border Grid.Column="3" BorderThickness="0 1 1 1">
                <TextBlock Text="Amount"/>
            </Border>
            <Border Grid.Column="4" BorderThickness="0 1 1 1">
                <TextBlock Text="Payment Due"/>
            </Border>
        </Grid>
        <ListBox Style="{StaticResource ListBoxStyle}"
                 ItemsSource="{Binding Source}"
                 SelectedItem="{Binding SelectedItem}"
                 IsHitTestVisible="{Binding IsSelectionActive}"
                 ItemTemplate="{Binding ItemTemplate}" />
    </Grid>
