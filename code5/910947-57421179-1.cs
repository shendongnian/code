using Excel = Microsoft.Office.Interop.Excel;
private static void Test()
{
    Excel.Range range = Application.ActiveWorkbook.ActiveSheet.Range["A1:B2"]; // 2x2 array
    range.Cells[1, 2] = "Foo"; // Sets Cell A2 to "Foo"
    dynamic[,] excelArray = range.Value2 as dynamic[,]; // This is a very fast operation
    Console.Out.WriteLine(excelArray[1, 2]); // => Foo
    excelArray[1, 2] = "Bar";
    range.Value2 = excelArray; // Sets Cell A2 to "Bar", again a fast operation even for large arrays
    Console.Out.WriteLine(range.Cells[1, 2]); // => Bar
Note that `excelArray` will have row and column lower bounds of 1:
    Console.Out.WriteLine("RowLB: " + excelArray.GetLowerBound(0)); // => RowLB: 1
    Console.Out.WriteLine("ColLB: " + excelArray.GetLowerBound(1)); // => ColLB: 1
BUT, if you declare a `newArray` in C# and assign it, then the lower bounds will be 0, but it will still work:
    dynamic[,] newArray = new dynamic[2, 2]; // Same dimensions as "A1:B2" (2x2)
    newArray[0, 1] = "Foobar";
    range.Value2 = newArray; // Sets Cell A2 to "Foobar"
    Console.Out.WriteLine(range.Cells[1, 2]); // => Foobar
Fetching this value out of the range will give you the original array with lower bounds of 0:
    range.Cells[1, 2] = "Fubar";
    dynamic[,] lastArray = range.Value2 as dynamic[,];
    Console.Out.WriteLine(lastArray[0, 1]); // => Fubar
    Console.Out.WriteLine("RowLB: " + lastArray.GetLowerBound(0)); // => RowLB: 0
    Console.Out.WriteLine("ColLB: " + lastArray.GetLowerBound(1)); // => ColLB: 0
}
Working with Excel Interop can be daunting as there are many special cases like this in the codebase, but I hope this helps clarify at least this one.
