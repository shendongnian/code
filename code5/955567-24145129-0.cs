    <TabControl>
        <TabControl.Triggers>
            <EventTrigger RoutedEvent="TabControl.SelectionChanged">
                <BeginStoryboard>
                    <Storyboard>
                        <DoubleAnimation From="0.25" To="1.0" Duration="0:0:1" 
                            Storyboard.TargetProperty="Opacity" />
                    </Storyboard>
                </BeginStoryboard>
            </EventTrigger>
        </TabControl.Triggers>
        <TabItem Header="Tab 1">
            <ListBox SelectionChanged="ListBox_SelectionChanged">
                <ListBoxItem>1</ListBoxItem>
                <ListBoxItem>2</ListBoxItem>
            </ListBox>
        </TabItem>
        <TabItem Header="Tab 2">
            <ListBox SelectionChanged="ListBox_SelectionChanged">
                <ListBoxItem>1</ListBoxItem>
                <ListBoxItem>2</ListBoxItem>
            </ListBox>
        </TabItem>
    </TabControl>
...
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        e.Handled = true;
    }
