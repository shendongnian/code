     <DataGrid AutoGenerateColumns="False" ItemsSource="{Binding SourceCollection}">
          <DataGrid.Columns>
             <DataGridTextColumn Binding="{Binding Index}"/>
            <asp:TemplateField HeaderText="Colour" SortExpression="Colour">
                <HeaderStyle Wrap="False" />
                <ItemStyle Wrap="False" />
                <ItemTemplate>
              <asp:Label ID="lblColor" Text='<%# Bind("Colour") %>' runat="server"></asp:Label>
                </ItemTemplate>
               </asp:TemplateField>
             <DataGridTextColumn Binding="{Binding Location}"/>
             <DataGridTextColumn Binding="{Binding Srno}"/>
          </DataGrid.Columns>
        </DataGrid>
