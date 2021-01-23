    var xlApp=new Microsoft.Office.Interop.Excel.Application();
    var wb=xlApp.Workbooks.Open(fn, ReadOnly: false);
    xlApp.Visible=true;
    var ws=wb.Worksheets[1] as Worksheet;
    var r=ws.Range["A2"].Resize[100, 1];
    var array=r.Value;
    // array is object[1..100,1..1]
    for(int i=1; i<=100; i++)
    {
        var text=array[i, 1] as string;
        Debug.Print(text);
    }
    // to create an [1..100,1..1] array use
    var array2=Array.CreateInstance(
        typeof(object), 
        new int[] {100, 1}, 
        new int[] {1, 1}) as object[,];
    // fill array2
    for(int i=1; i<=100; i++)
    {
        array2[i, 1] = string.Format("Text{0}",i);
    }
    r.Value2=array2;
    wb.Close(SaveChanges: true);
    xlApp.Quit();
