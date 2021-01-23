    private void listBox1_MouseMove(object sender, MouseEventArgs e)
    {
        showItemData(e.Location);
    }
    ToolTip tt = new ToolTip();
    void showItemData()
    {
        Point point = listBox1.PointToClient(Cursor.Position);
        int index = listBox1.IndexFromPoint(point);
        if (index <= 0) return;
        //Do your thing with the item:
        tt.Show(listBox1.Items[index].ToString(), listBox1, pt);
        Console.WritLine(  listBox1.Items[index].ToString()  );
    }
