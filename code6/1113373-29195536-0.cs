    <StackPanel>
        <RichTextBox Width="100" Height="200" x:Name="txtRich"/>
        <Button Content="Set Arial Font" Click="Button_Click"/>
        <Button Content="Set Tahoma Font" Click="Button_Click_1"/>
    </StackPanel>
     private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!txtRich.Selection.IsEmpty)
            {
                TextRange selectionTextRange = new TextRange(txtRich.Selection.Start, txtRich.Selection.End);
                selectionTextRange.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Arial"));
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!txtRich.Selection.IsEmpty)
            {
                TextRange selectionTextRange = new TextRange(txtRich.Selection.Start, txtRich.Selection.End);
                selectionTextRange.ApplyPropertyValue(TextElement.FontFamilyProperty, new FontFamily("Tahoma")); 
            }
        }
