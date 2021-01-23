    using (var f = new H5File("myFile.h5")) {
        // create container for the dataset contents
        ILCell c = cell(size(1, 1)); // one element init
        // retrieve datasets filtered
        var matches = f.Find<H5Dataset>(predicate: ds => {
            if (ds.Attributes.Any(a => a.Name.Contains("att"))) {
                c[end + 1] = ds.Get<double>();
                return true; 
            }
            return false; 
        });
        return c; 
    }
