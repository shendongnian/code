    Task.StartNew(BackgroundLabelToggle, Label[] {  lblIF, lblID });
    private static void BackgroundLabelToggle(Label[] labels)
    {
       var a = labels[0];
       var b = labels[1];
       a.Invoke(LabelUpdater, a); //to bold
       Thread.Sleep(500);
       a.Invoke(LabelUpdater, a); //to regular again
       b.Invoke(LabelUpdater, b); //to bold
       Thread.Sleep(500);
       b.Invoke(LabelUpdater, b); //to regular again
    }
