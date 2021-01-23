    <Button x:Name="OuterButton" Click="Button_Click">
        <!-- // Set DataContext to a string equal to "OuterButton.DataContext" -->
        <Button.DataContext>
            OuterButton.DataContext
        </Button.DataContext>
        <!-- // Set Content to a string equal to "OuterButton.DataContext" -->
        <Button.Content>
            OuterButton.Content
        </Button.Content>
        <Button.ContentTemplate>
            <DataTemplate>
                <StackPanel>
                    <Button x:Name="InnerButton" Content="InnerButton.Content" Click="Button_Click" />
                    <TextBlock FontWeight="Bold" Text="{Binding }"/>
                </StackPanel>
            </DataTemplate>
        </Button.ContentTemplate>
    </Button>
