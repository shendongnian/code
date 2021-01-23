    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid x:Name="LayoutRoot">
            <Hub x:Name="Hub" x:Uid="Hub" Header="ducommerce" Background="{StaticResource background}">
                <HubSection x:Uid="HubSection1" Header="{Binding SpecialDishes.Name}" >
                    <DataTemplate>
                        <ListView
                    ItemsSource="{Binding Items}"
                    IsItemClickEnabled="True">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <Button Content="testbtn"></Button>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                            <ListView.ItemContainerStyle>
                                <Style TargetType="ListViewItem">
                                    <Setter Property="Padding" Value="0"/>
                                    <Setter Property="Margin" Value="0,0,0,12"/>
                                </Style>
                            </ListView.ItemContainerStyle>
                        </ListView>
                    </DataTemplate>
                </HubSection>
                <HubSection x:Uid="HubSection1" Header="{Binding SpecialDishes.Name}" >
                    <DataTemplate>
                        <ListView
                    ItemsSource="{Binding Items}"
                    IsItemClickEnabled="True">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <Button Content="testbtn"></Button>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                            <ListView.ItemContainerStyle>
                                <Style TargetType="ListViewItem">
                                    <Setter Property="Padding" Value="0"/>
                                    <Setter Property="Margin" Value="0,0,0,12"/>
                                </Style>
                            </ListView.ItemContainerStyle>
                        </ListView>
                    </DataTemplate>
                </HubSection>
               
                <!--<HubSection x:Uid="HubSection1" Header="{Binding SpecialDishes.Name}" >
                    <DataTemplate>
                        <ListView
                    ItemsSource="{Binding Items}"
                    IsItemClickEnabled="True">
                            <ListView.ItemTemplate>
                                <DataTemplate>
                                    <Button Content="testbtn"></Button>
                                </DataTemplate>
                            </ListView.ItemTemplate>
                            <ListView.ItemContainerStyle>
                                <Style TargetType="ListViewItem">
                                    <Setter Property="Padding" Value="0"/>
                                    <Setter Property="Margin" Value="0,0,0,12"/>
                                </Style>
                            </ListView.ItemContainerStyle>
                        </ListView>
                    </DataTemplate>
                </HubSection>-->
            </Hub>
        </Grid>
    </Grid>
