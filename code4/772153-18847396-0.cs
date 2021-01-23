    <Window.Resources>
        <Style x:Key="MyMenuStyle" TargetType="{x:Type MenuItem}" >
            <Setter Property="HeaderTemplate" >
                <Setter.Value>
                    <DataTemplate>
                        <TextBlock>
                            <TextBlock.Text>
                                <MultiBinding StringFormat="{}{0}. {1}">
                                    <Binding Path="(ItemsControl.AlternationIndex)" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type MenuItem}}"/>
                                    <Binding Path="FullFileName"/>
                                </MultiBinding>
                            </TextBlock.Text>
                        </TextBlock>
                    </DataTemplate>
                </Setter.Value>
            </Setter>
        </Style>
    </Window.Resources>
    <Grid>
        <Menu VerticalAlignment="Top">
            <MenuItem Header="_FILE" >
                <MenuItem Header="_Recent Studies" 
                          ItemsSource="{Binding RecentFiles}"
                          AlternationCount="{Binding RecentFiles.Count}"
                          ItemContainerStyle="{StaticResource MyMenuStyle}" />
                <Separator/>
                <MenuItem Header="E_xit" Height="22" Command="{Binding ExitCommand}" />
            </MenuItem>
        </Menu>
    </Grid>
