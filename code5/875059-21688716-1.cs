    // initialize some default elements to use later if
    // they're of the same type then a single default is fine
    var defaultPhysex = new {...};
    var defaultCallrc = new {...};
    var left = from callrc in callrecdt.AsEnumerable()
               join physex in physextns.AsEnumerable()
                 on callrc["Extn_In_Call_Records"] equals physx["Extn_Number"]
               into temp
               from physex in temp.DefaultIfEmpty(defaultPhysex)
             select new 
             {
                 // callrc is accessible here, as is the new physex
                 Field1 = ...,
                 Field2 = ...,
             }
    var right = from physex in physextns.AsEnumerable()
                join callrc in callrecdt.AsEnumerable()
                  on callrc["Extn_In_Call_Records"] equals physx["Extn_Number"]
                into temp
                from callrc in temp.DefaultIfEmpty(defaultCallrc)
                select new 
                {
                    // physex is accessible here, as is the new callrc
                    Field1 = ...,
                    Field2 = ...,
                }
    var union = left.Union(right);
