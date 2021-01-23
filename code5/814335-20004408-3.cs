    public partial class Form1 : Form {
      public Form1(){
         InitializeComponent();
         //suppose you have a main ContextMenuStrip and a sub ContextMenuStrip
         //try adding some items for both
         ContextMenuStrip = new ContextMenuStrip();
         ContextMenuStrip.Items.Add("Item 1");
         ContextMenuStrip.Items.Add("Item 2");
         //sub ContextMenuStrip
         var subMenu = new ContextMenuStrip();
         subMenu.Items.Add("Delete");
         subMenu.Items.Add("Rename");  
         ContextMenuStrip.HandleCreated += (s,e) => {
           nativeMenu.AssignHandle(ContextMenuStrip.Handle);
           nativeMenu.ShowContextMenu += (ev) => {
              ev.ContextMenuToShow = subMenu;
           };
         };
      }
      NativeContextMenuStrip nativeMenu = new NativeContextMenuStrip();
    }
