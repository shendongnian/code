    public class MyClass
            {
                public int RowID { get; set; }
                public string Data { get; set; }
                public string RowMod { get; set; }
            }
            
    var result = (from id in myList.Select(x => x.RowID).Distinct()
                    let oldData = myList.Where(x => x.RowID == id).SingleOrDefault(x => x.RowMod.Equals("")) != null ? myList.Where(x => x.RowID == id).Single(x => x.RowMod.Equals("")).Data : null
                    let newData = myList.Where(x => x.RowID == id).SingleOrDefault(x => !x.RowMod.Equals("")) != null ? myList.Where(x => x.RowID == id).Single(x => !x.RowMod.Equals("")).Data : null
                    let rowMod = myList.Where(x => x.RowID == id).SingleOrDefault(x => !x.RowMod.Equals("")) != null ? myList.Where(x => x.RowID == id).Single(x => !x.RowMod.Equals("")).RowMod : null
                    select new
                           {
                               RowID = id, OldData = oldData, NewData = newData, RowMod = rowMod
                           });
