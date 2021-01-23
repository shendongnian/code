     <TreeView Name="testPlanTview" Margin="0,10,283,0">
        <TreeViewItem ItemsSource="{Binding Connections}" Header="Test Plan">
       <i:Interaction.Triggers>
             <i:EventTrigger EventName="SelectedItemChanged">
                 <i:InvokeCommandAction Command="{Binding OpenNewViewCommand}" 
                  CommandParameter="{Binding SelectedItem,ElementName=testPlanTview}"/>
             </i:EventTrigger>
       </i:Interaction.Triggers>
    </TreeViewItem>
    </TreeView>
      <ContentControl prism:RegionManager.RegionName="MyRegion"/>
