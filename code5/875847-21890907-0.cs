    <StackPanel>
        <Label Content="StackOverflow" HorizontalAlignment="Center"
               TouchMove="Label_TouchMove" />
        <Label Content="Drag to here"
               HorizontalAlignment="Center"
               AllowDrop="True" Drop="Label_Drop" />
    </StackPanel>
    // Drag source
    private void Label_TouchMove(object sender, TouchEventArgs e)
    {
        Label l = e.Source as Label;
        DragDrop.DoDragDrop(l, l.Content + " was Dragged!", DragDropEffects.Copy);
    }
     
    // Drag target
    private void Label_Drop(object sender, DragEventArgs e)
    {
        string draggedText = (string)e.Data.GetData(DataFormats.StringFormat);
        Label l = e.Source as Label;
        l.Content = draggedText;
    }
