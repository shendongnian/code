    public class ImgStringTemplateSelector : DataTemplateSelector
    {
      public DataTemplate ImageTemplate { get; set; }
      public DataTemplate StringTemplate { get; set; }
    
      public override DataTemplate SelectTemplate(object item, 
        DependencyObject container)
      {
        String path = (string)item;
        String ext = System.IO.Path.GetExtension(path);
        if (System.IO.File.Exists(path) && ext == ".jpg")
          return ImageTemplate;
        return StringTemplate;
      }
    }
      <Window.Resources>
        <local:RelativeToAbsolutePathConverter x:Key="relToAbsPathConverter" />
    
        <DataTemplate x:Key="stringTemplate">
          <TextBlock Text="{Binding}"/>
        </DataTemplate>
    
        <DataTemplate x:Key="imageTemplate">
          <Image Source="{Binding Converter={StaticResource relToAbsPathConverter}}" 
                 Stretch="UniformToFill" Width="200"/>
        </DataTemplate>
    
        <local:ImgStringTemplateSelector 
            ImageTemplate="{StaticResource imageTemplate}" 
            StringTemplate="{StaticResource stringTemplate}" 
            x:Key="imgStringTemplateSelector" />
      </Window.Resources>
    
      <Grid>
        <ListView ScrollViewer.CanContentScroll="False" 
                  ItemsSource="{Binding ElementName=This, Path=PathCollection}" 
                  ItemTemplateSelector="{StaticResource imgStringTemplateSelector}">
        </ListView>
      </Grid>
    </Window>
