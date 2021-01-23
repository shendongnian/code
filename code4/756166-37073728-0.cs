    public class MyDraggedData
    {
        public object Data { get; set; }
    }
    private void stack_MouseDown(object sender, System.Windows.Input.MouseEventArgs e)
    {
        StackPanel sp = (StackPanel)sender;
        MyDraggedData data = new MyDraggedData();
        data.Data = sp.Tag;
        DragDrop.DoDragDrop(sp, data, DragDropEffects.Copy);
    }
    private void Map_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
    {
      MyDraggedData data = (MyDraggedData)e.Data.GetData(typeof(MyDraggedData));
      List<Object> obj = (List<Object>)data.Data;
    }
