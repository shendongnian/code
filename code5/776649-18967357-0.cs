     using System;
     using Gtk;
     class ComboBoxSample
     {
          static void Main ()
          {
               new ComboBoxSample ();
          }
          ComboBoxSample ()
          {
               Application.Init ();
               Window win = new Window ("ComboBoxSample");
               win.DeleteEvent += new DeleteEventHandler (OnWinDelete);
               ComboBox combo = ComboBox.NewText ();
               for (int i = 0; i < 5; i ++)
                    combo.AppendText ("item " + i);
               combo.Changed += new EventHandler (OnComboBoxChanged);
               win.Add (combo);
               win.ShowAll ();
               Application.Run ();
          }
          void OnComboBoxChanged (object o, EventArgs args)
          {
               ComboBox combo = o as ComboBox;
               if (o == null)
                    return;
               TreeIter iter;
               if (combo.GetActiveIter (out iter))
                    Console.WriteLine ((string) combo.Model.GetValue (iter, 0));
          }
          void OnWinDelete (object obj, DeleteEventArgs args)
          {
               Application.Quit ();
          }
     }
