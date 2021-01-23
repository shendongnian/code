    public class ListBoxRow : Row {}
    public class TextBoxRow : Row {}
    
    List<Row> rows = new List<Row>(){new ListBoxRow(), new TextBoxRow()}
    
    foreach (Row r in rows)
    {
        If (r is ListBoxRow) {//Create ListBox }
        If (r is TextBoxRow ) {//Create TextBox }
    }
