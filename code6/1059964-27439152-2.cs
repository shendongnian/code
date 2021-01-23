     <Grid >
        <ScrollViewer ScrollViewer.VerticalScrollBarVisibility="Auto" Margin="10" Background="White">
            <Grid>
                <Label Name="lblstatus" HorizontalAlignment="center" VerticalAlignment="top" Margin="10" FontSize="14" FontWeight="bold" Foreground="Black" >Please wait...</Label>
                <ListBox  ItemsSource="{Binding}"  Name="TOCView"  ItemContainerStyle="{StaticResource ListBoxItemStyle}">
                    <ItemsControl.ItemTemplate>
                        <DataTemplate>
                            <Expander x:Name="Expander" ExpandDirection="Down" IsExpanded="{Binding Mode=TwoWay, Path=IsSelected, RelativeSource={RelativeSource AncestorType=ListBoxItem, Mode=FindAncestor}}"  >
                                <Expander.Style>
                                    <Style TargetType="Expander" BasedOn="{StaticResource ExpanderItemStyle}">
                                        <Setter Property="Template" Value="{StaticResource WithToggleButton}"/>
                                        <Style.Triggers>
                                            <DataTrigger Binding="{Binding Path=chapters}" Value="{x:Null}">
                                                <Setter Property="Template" Value="{StaticResource WithoutToggleButton}"/>
                                            </DataTrigger>
                                        </Style.Triggers>
                                    </Style>
                                </Expander.Style>
                                <Expander.Header> 
                                    <BulletDecorator>
                                        <Button Tag="{Binding}"  Style="{StaticResource ResourceKey=BookPageStyle}" Click="MainChapterButton_Click"  Content="{Binding Path=name}"/>
                                    </BulletDecorator>
                                </Expander.Header>
                                <Expander.Content>
                                    <StackPanel>
                                        <ListBox x:Name="SubChapListBox" BorderThickness="0" Margin="20,0" ItemsSource="{Binding Path=chapters}"  ItemContainerStyle="{StaticResource ListBoxItemStyle}">
                                            <ListBox.ItemTemplate>
                                                <DataTemplate>
                                                    <Expander Name="Expander1" ExpandDirection="Down"  BorderThickness="0">
                                                        <Expander.Style>
                                                            <Style TargetType="Expander" BasedOn="{StaticResource ExpanderItemStyle}">
                                                                <Setter Property="Template" Value="{StaticResource WithToggleButton}"/>
                                                                <Style.Triggers>
                                                                    <DataTrigger Binding="{Binding Path=chapters}" Value="{x:Null}">
                                                                        <Setter Property="Template" Value="{StaticResource WithoutToggleButton}"/>
                                                                    </DataTrigger>
                                                                </Style.Triggers>
                                                            </Style>
                                                        </Expander.Style>
                                                        <Expander.Header>
                                                            <BulletDecorator>
                                                                <Button Tag="{Binding}"  Style="{StaticResource ResourceKey=BookPageStyle}" Click="SubchpaterButton_Click"  Content="{Binding Path=name}"/>
                                                            </BulletDecorator>
                                                        </Expander.Header>
                                                        <StackPanel>
                                                            <ListBox x:Name="SubChapListBox" BorderThickness="0" Margin="20,0" ItemsSource="{Binding Path=chapters}"  ItemContainerStyle="{StaticResource ListBoxItemStyle}">
                                                                <ListBox.ItemTemplate>
                                                                    <DataTemplate>
                                                                        <Expander Name="expander2" ExpandDirection="Down"  BorderThickness="0"  >
                                                                            <Expander.Style>
                                                                                <Style TargetType="Expander">
                                                                                    <Setter Property="Template" Value="{StaticResource WithToggleButton}"/>
                                                                                    <Style.Triggers>
                                                                                        <DataTrigger Binding="{Binding Path=chapters}" Value="{x:Null}">
                                                                                            <Setter Property="Template" Value="{StaticResource WithoutToggleButton}"/>
                                                                                        </DataTrigger>
                                                                                    </Style.Triggers>
                                                                                </Style>
                                                                            </Expander.Style>
                                                                            <Expander.Header>
                                                                                <BulletDecorator>
                                                                                    <Button Tag="{Binding}"  Style="{StaticResource ResourceKey=BookPageStyle}" Click="SubchpaterButton_Click"  Content="{Binding Path=name}"/>
                                                                                </BulletDecorator>
                                                                            </Expander.Header>
                                                                        </Expander>
                                                                    </DataTemplate>
                                                                </ListBox.ItemTemplate>
                                                            </ListBox>
                                                        </StackPanel>
                                                    </Expander>
                                                </DataTemplate>
                                            </ListBox.ItemTemplate>
                                        </ListBox>
                                    </StackPanel>
                                </Expander.Content>
                            </Expander>
                        </DataTemplate>
                    </ItemsControl.ItemTemplate>
                </ListBox>
            </Grid>
        </ScrollViewer>
    </Grid>
