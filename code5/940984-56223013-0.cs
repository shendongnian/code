for (int i = 6; i<e.Row.Cells.Count; i++)
{
    e.Row.Cells[i].Visible = false;
}
...which worked, but all the headers for those columns were still there.  I was able to solve that by adding this line to the loop:
for (int i = 6; i<e.Row.Cells.Count; i++)
{
    e.Row.Cells[i].Visible = false;
    GridView1.HeaderRow.Cells[i].Visible = false;
}
Now the columns and headers are in sync.  I'm not excited that I had to reference the GridView1 itself in the event handler, so if someone knows of a way to improve that, please go ahead.
I was eliminating everything after column 5, but you could use the same concept to hide any specific column/header.  Hope that helps.
