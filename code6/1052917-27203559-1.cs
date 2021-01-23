    private void listStudent_MouseMove(object sender, MouseEventArgs e)
    {
        showItemData(e.Location);
    }
    ToolTip tt = new ToolTip();
    void showItemData()
    {
        Point point = listStudent.PointToClient(Cursor.Position);
        int index = listStudent.IndexFromPoint(point);
        if (index <= 0) return;
        //Do your thing with the item:
        tt.Show(listStudent.Items[index].ToString(), listStudent, pt);
        Console.WritLine(  listStudent.Items[index].ToString()  );
    }
