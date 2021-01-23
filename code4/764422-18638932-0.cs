        public class CustomLineGraph : LineGraph {
            public static readonly RoutedEvent ThicknessEvent = EventManager.RegisterRoutedEvent("Thickness", RoutingStrategy.Bubble, typeof(RoutedEventHandler, typeof(CustomLineGraph));
            
            // .NET event wrapper
            public event RoutedEventHandler Thickness
            {
                add { AddHandler(CustomLineGraph.ThicknessEvent, value); } 
                remove { RemoveHandler(CustomLineGraph.ThicknessEvent, value); }
            }
        }
