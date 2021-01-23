    private static void ForceMeasureItems(ListBox listBox, Action<object, MeasureItemEventArgs> onMeasureEvent)
    {
        for (int i = 0; i < listBox.Items.Count; i++)
        {
            MeasureItemEventArgs eArgs = new MeasureItemEventArgs(listBox.CreateGraphics(), i);
            onMeasureEvent(listBox, eArgs);
            SendMessage(listBox.Handle, LB_SETITEMHEIGHT, i, eArgs.ItemHeight);
        }
        listBox.Refresh();
    }
