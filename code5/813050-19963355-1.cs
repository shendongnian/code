    <Grid.Resources>
        <XmlNamespaceMappingCollection x:Key="myNamespaces">
           <XmlNamespaceMapping Uri="http://www.somenamespace.com" Prefix="namespace1"/>
           <XmlNamespaceMapping Uri="http://www.anothernamespace.com" Prefix="namespace2"/>
        </XmlNamespaceMappingCollection>
    
        <XmlDataProvider x:Key="applicants" XmlNamespaceManager="{StaticResource myNamespaces}" Source="sample.xml" />
    </Grid.Resources>
    <DataGrid x:Name="applicantGrid" DataContext="{StaticResource applicants}" ItemsSource="{Binding XPath=/data/row}" AutoGenerateColumns="False" Margin="12,12,31,12" SelectionChanged="applicantGrid_SelectionChanged">
        <DataGrid.Columns>
            <DataGridTextColumn Header="ResumeID" Binding="{Binding XPath=namespace1:ResumeID}" />
            <DataGridTextColumn Header="Name" Binding="{Binding XPath=namespace2:FullName}" />
        </DataGrid.Columns>
    </DataGrid>
