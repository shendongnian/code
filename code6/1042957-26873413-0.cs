    <Application.Resources>
    
      <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
          <ResourceDictionary Source="/UMLDiagram.Windows.Theme;component/Theme.xaml"/>
        </ResourceDictionary.MergedDictionaries>
    
        <DataTemplate DataType="{x:Type Model:ClassData}">
          <Canvas>
            <View:ClassDataUserControl/>
          </Canvas>
        </DataTemplate>
    
        <DataTemplate DataType="{x:Type Model:Connector}">
          <Canvas>
            <View:ConnectorUserControl/>
          </Canvas>
        </DataTemplate>
      </ResourceDictionary>
    
    </Application.Resources>
