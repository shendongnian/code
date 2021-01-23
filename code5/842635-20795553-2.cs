    foreach ( GridViewRow rw in GridView1.Rows)
    {
    if (rw.Cell[0].Text =="F")
    {
            rw.Cells[0].Text ="CF";
    }
    else if (rw.Cells[1].Text =="N")
    {
           rw.Cells[1].Text ="CN";
    }
    }
