    public static void Restore(DockingManager dockingManager, string file)
    {
      if (File.Exists(file))
      {
        try
        {
          var serializer = new XmlLayoutSerializer(dockingManager);
    
          // Imparitive for Deserialization
          serializer.LayoutSerializationCallback += (s, args) =>
          {
            args.Content = args.Content;
          };
    
          serializer.Deserialize(file);
    
          var laToDelete = Singleton.WindowMain.DocumentPane.Children
            .OfType<LayoutAnchorable>()
            .ToList();
          for (var index = 0; index < laToDelete.Count; index++)
          {
            LayoutAnchorable layoutAnchorable = laToDelete[index];
            Singleton.WindowMain.DocumentPane.Children.Remove(layoutAnchorable);
          }
        }
        catch
        {
          File.Delete(file);
        }
    
      }
    }
