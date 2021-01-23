        <Style TargetType="{x:Type ListBoxItem}">
            <Style.Triggers>
                <EventTrigger RoutedEvent="PreviewMouseDown">
                    <EventTrigger.Actions>
                        <action:WorksheetListBoxAction />
                    </EventTrigger.Actions>
                </EventTrigger>
            </Style.Triggers>
        </Style>
