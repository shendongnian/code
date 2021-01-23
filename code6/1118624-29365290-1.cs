    var ctrls = parentForm.Controls.Find("mediaPlayer", true);
    Type t = typeof(Panel);
    object[] p = new object[1];
    p[0] = new DragEventArgs(new DataObject(DataFormats.FileDrop, new string[] {@"d:\test\test.avi"}), 0, 0,0, DragDropEffects.Copy, DragDropEffects.Copy);
    MethodInfo m = t.GetMethod("OnDragDrop", BindingFlags.NonPublic | BindingFlags.Instance);
    m.Invoke(ctrls[0], p);
