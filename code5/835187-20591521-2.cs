    <ItemsControl ItemsSource="{Binding ItemList}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Button Click="Button_OnClick">
                    <Button.Template>
                        <ControlTemplate TargetType="Button">
                            <Grid Height="108" Width="Auto" Margin = "6,6">
                                <Grid.RowDefinitions>
                                    <RowDefinition Height="Auto"/>
                                    <RowDefinition Height="*"/>
                                </Grid.RowDefinitions>
                                <Image Width = "54" Height="54" Stretch="UniformToFill" Grid.Row="0">
                                    <Image.Source>
                                        <BitmapImage UriSource="{Binding ImageUri}" CreateOptions="BackgroundCreation"/>
                                    </Image.Source>
                                </Image>
                                <TextBlock Text="{Binding Name}"
                                           Foreground ="{StaticResource PhoneAccentBrush}" />
                            </Grid>
                        </ControlTemplate>
                    </Button.Template>
                </Button>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
       
