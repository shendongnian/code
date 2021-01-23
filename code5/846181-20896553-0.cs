    Table table = document.LastSection.AddTable();
    table.Borders.Visible = true;
    table.Format.Shading.Color = Colors.LavenderBlush;
    table.Shading.Color = Colors.Salmon;
    table.TopPadding = 5;
    table.BottomPadding = 5;
 
    Column column = table.AddColumn();
    column.Format.Alignment = ParagraphAlignment.Left;
 
    column = table.AddColumn();
    column.Format.Alignment = ParagraphAlignment.Center;
 
    column = table.AddColumn();
    column.Format.Alignment = ParagraphAlignment.Right;
 
    table.Rows.Height = 35;
 
    Row row = table.AddRow();
    row.VerticalAlignment = VerticalAlignment.Top;
    row.Cells[0].AddParagraph("Text");
    row.Cells[1].AddParagraph("Text");
    row.Cells[2].AddParagraph("Text");
 
    row = table.AddRow();
    row.VerticalAlignment = VerticalAlignment.Center;
    row.Cells[0].AddParagraph("Text");
    row.Cells[1].AddParagraph("Text");
    row.Cells[2].AddParagraph("Text");
 
    row = table.AddRow();
    row.VerticalAlignment = VerticalAlignment.Bottom;
    row.Cells[0].AddParagraph("Text");
    row.Cells[1].AddParagraph("Text");
    row.Cells[2].AddParagraph("Text");
   
