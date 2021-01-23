    <ListBox x:Name="lbname" ItemsSource="{Binding myCollection}">
        <ListBox.ItemTemplate>
            <DataTemplate>
                <ToggleButton x:Name="btnname" Click="btnname_Click" IsChecked="{Binding 
    IsSelected, RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type 
    ListBoxItem}}}">
                    <Grid>
                        <Image>
                            <Image.Style>
                                <Style>
                                    <Setter Property="Image.Source" 
    Value="/myApplication;component/images/buttons/normal.png" />
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding IsSelected, 
    RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ListBoxItem}}}" 
    Value="True">
                                            <Setter Property="Image.Source" 
    Value="/myApplication;component/images/buttons/click.png" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                            </Image.Style>
                        </Image>
                        <TextBlock Text="{Binding name}" HorizontalAlignment="Center" 
    VerticalAlignment="Center" />
                    </Grid>
                </ToggleButton>
            </DataTemplate>
        </ListBox.ItemTemplate>
    </ListBox>
