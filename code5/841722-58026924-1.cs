int[] arr = { 10, 5, 10, 2, 2, 3, 4, 5, 5, 6, 7, 8, 9, 11, 12, 12 };
var result = arr.GroupBy(x => x).Select(x => new { key = x.Key, val = x.Count() });       
foreach (var item in result)
{
    if(item.val > 1)
    {                
        Console.WriteLine("Duplicate value : {0}", item.key);
        Console.WriteLine("MaxCount : {0}", item.val);
    }
            
}
       
Console.ReadLine();
