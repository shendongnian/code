    <Grid>
        <Button Content="Add Question" Command="{Binding AddQuestionCommand}" Margin="615,19,179,724" />
        <Button Content="Add Title" Command="{Binding AddTitleCommand}" Margin="474,19,320,724" />
        <StackPanel>
            <ItemsControl ItemsSource="{Binding Title}">
                <ItemsControl>
                    <ItemsControl.ItemContainerStyle>
                        <Style>
                            <Setter Property="FrameworkElement.Margin" Value="20,20,0,0"/>
                        </Style>
                    </ItemsControl.ItemContainerStyle>
                </ItemsControl>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding .}" Width="200" HorizontalAlignment="Left" />
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
            <ItemsControl ItemsSource="{Binding Question}">
                <ItemsControl>
                    <ItemsControl.ItemContainerStyle>
                        <Style>
                            <Setter Property="FrameworkElement.Margin" Value="40,20,0,0"/>
                        </Style>
                    </ItemsControl.ItemContainerStyle>
                </ItemsControl>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <TextBox Text="{Binding .}" Width="200" HorizontalAlignment="Left"/>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
        </StackPanel>
    </Grid>
