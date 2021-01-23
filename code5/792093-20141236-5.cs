        foreach (var eventToUnsubscribe in grid.Triggers.OfType<EventTrigger>()
                                                      .Where(x => x.RoutedEvent == UIElement.MouseEnterEvent
                                                                  || x.RoutedEvent == UIElement.MouseLeaveEvent).ToList())
        {
            grid.Triggers.Remove(eventToUnsubscribe);
        };
