     <Maps:MapItemsControl x:Name="MapIcons" >
        <Maps:MapItemsControl.ItemTemplate>
            <DataTemplate>
                 ........
                 .......
            </DataTemplate>
         </Maps:MapItemsControl.ItemTemplate>
     </Maps:MapItemsControl>
    class MapIcon
    {
       public String id { get; set; }
       public String name { get; set; }
       public String description { get; set; }
       public String picture { get; set; }
       public Geopoint MapLocation { get; set; }
    }
    funtion
    {
         Double latitude = item.latitude;
         Double longitude = item.longitude;
         Geopoint location = new Geopoint(new BasicGeoposition()
         {
            Latitude = latitude,
            Longitude = longitude,
         });
         MapIcon icon = new MapIcon() { MapLocation = location, name = name, picture = picture ,description = description};
         icons.Add(icon);
    }
    MapIcons.ItemsSource = icons;  
