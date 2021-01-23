    public Form1(){
      InitializeComponent();
      listView1.OwnerDraw = true;
      invalidateHeaders = typeof(ListView).GetMethod("InvalidateColumnHeaders",
                                           System.Reflection.BindingFlags.NonPublic |
                                           System.Reflection.BindingFlags.Instance);
    } 
    
    bool hot;
    System.Reflection.MethodInfo invalidateHeaders;
    //DrawColumnHeader event handler
    private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
      if (e.Header.TextAlign == HorizontalAlignment.Right) {
          e.DrawBackground();
          e.DrawText(TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
          if (e.Bounds.Contains(listView1.PointToClient(MousePosition))) {
              bool selected = (e.State & ListViewItemStates.Selected) != 0;
              var solidColor = selected ? Color.FromArgb(30, Color.FromArgb(0, 200, 200)) :
                                          Color.FromArgb(30, Color.Aqua);
              var borderColor = selected ? Color.DarkGray : Color.Aqua;
              e.Graphics.FillRectangle(new SolidBrush(solidColor), e.Bounds);
              var rect = e.Bounds;
              rect.Width -= 2;
              rect.Height -= 2;                    
              ControlPaint.DrawBorder(e.Graphics, rect, 
                           Color.FromArgb(40, borderColor), ButtonBorderStyle.Solid);
              hot = true;
           }
           hot = false;
       } else {
           e.DrawDefault = true;
           if (hot) {
              invalidateHeaders.Invoke(listView1, null);
              hot = false;
           }
       }
    }
    //DrawItem event handler
    private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e) {
       e.DrawDefault = true;
    }
    //MouseMove event handler
    private void listView1_MouseMove(object sender, MouseEventArgs e) {
       invalidateHeaders.Invoke(listView1, null);
    }    
