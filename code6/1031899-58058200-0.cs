    using System.Linq;
    public MyFormConstructor()
    {
        InitializeComponent();
        VScrollBar scrollBar = dgv.Controls.OfType<VScrollBar>().First();
        scrollBar.EndScroll += MyEndScrollEventHandler;
    }
    private void MyEndScrollEventHandler(object sender, ScrollEventArgs e)
    {
       if (dgv.Rows[dgv.RowCount - 1].Displayed){ // Check whether last row is visible
          //do something
       }
    }
