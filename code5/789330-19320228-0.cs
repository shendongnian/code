    using Gtk;
    using System;
    
    public class ButtonApp  
    {
            public static int Main (string[] args)
            {
                    Application.Init ();
                    Window win = new Window ("Button Tester");
                    win.SetDefaultSize (200, 150);
                    win.DeleteEvent += new DeleteEventHandler (Window_Delete);
                    Button btn = new Button ("Click Me");
                    btn.Image = Image.LoadFromResource("pic");
                    win.Add (btn);
                    win.ShowAll ();
                    Application.Run ();
                    return 0;
            }
            static void Window_Delete (object obj, DeleteEventArgs args)
            {
                    Application.Quit ();
                    args.RetVal = true;
            }
    }
