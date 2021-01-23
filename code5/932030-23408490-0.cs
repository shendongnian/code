      <DataGrid ItemSource="{Binding YourCollection}" SelectedItem="{Binding YourCurrentSelectedItem}">
          <DataGrid.Columns>
             <DataGridTextColumn Header="SomeColumnHeader" Binding={Binding SomePropertyOnTheModel} />
          </DataGrid.Columns>
      </DataGrid>
