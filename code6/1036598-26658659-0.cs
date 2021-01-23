    <ListBox x:Name="lsbTriggers" ItemsSource="{Binding SelectedProductPart.TriggerViewModels}">
         <ListBox.ItemTemplate>
           <HierarchicalDataTemplate >
              <ComboBox SelectedItem="{Binding WatchedVariable}" 
                   ItemsSource="{Binding DataContext.SelectedProductPart.AllVariables,
                         RelativeSource={RelativeSource AncestorType=ListBox}}" >
              </ComboBox>
           </HierarchicalDataTemplate>
         </ListBox.ItemTemplate>
    </ListBox>
