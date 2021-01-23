    //your form constructor
    public Form1(){
      InitializeComponent();
      listBox1.DrawMode = DrawMode.OwnerDrawVariable;
      listBox1.ItemHeight = 18;//setting this to change the height of all items
      listBoxWndProc = typeof(Control).GetMethod("WndProc", 
                                                 System.Reflection.BindingFlags.NonPublic |
                                                 System.Reflection.BindingFlags.Instance);
      //the initial selected index is 0
      SetItemHeight(0, selectedItemHeight);
      listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged;  
      
    }
    int selectedItemHeight = 25;
    int lastSelectedIndex;
    private System.Reflection.MethodInfo listBoxWndProc;
    private void SetItemHeight(int index, int height) {
       var h = Math.Min(255, height);//the maximum height is 255
       //LB_SETITEMHEIGHT = 0x1a0
       Message msg = Message.Create(listBox1.Handle, 0x1a0, (IntPtr)index, (IntPtr)h);
       listBoxWndProc.Invoke(listBox1, new object[] { msg });
    }
    //handle the SelectedIndexChanged to update the selected item height
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e){
      //Reset the height of the last selected item
      SetItemHeight(lastSelectedIndex, listBox1.ItemHeight);
      int minIndex = Math.Min(lastSelectedIndex, listBox1.SelectedIndex);
      int maxIndex = Math.Max(lastSelectedIndex, listBox1.SelectedIndex);                
      lastSelectedIndex = listBox1.SelectedIndex;
      SetItemHeight(lastSelectedIndex, selectedItemHeight);
      var rect1 = listBox1.GetItemRectangle(minIndex);
      var rect2 = listBox1.GetItemRectangle(maxIndex);
      listBox1.Invalidate(new Rectangle(rect1.X, rect1.Y, 
                                        rect1.Width, rect2.Bottom - rect1.Top)); 
    }
