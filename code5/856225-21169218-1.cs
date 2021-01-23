    <GridViewColumn.CellTemplate>
        <DataTemplate>
            <Button Tag="{Binding Serial}" Template="{DynamicResource copyPaste}" Click="cell_click" Style="{DynamicResource copyPasteStyle}" />
        </DataTemplate>
    </GridViewColumn.CellTemplate>
