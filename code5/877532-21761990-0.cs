       var writeToDisk = false;
       var outfile  = new MemoryStream();
       foreach(a line of strings)
       {
           // process the line
           // BTW: the `String.Format` you have here is exceptionally confusing
           // and may be attributing to why everything is \0
           outfile.Write(...);
           // set the flag to `true` on some condition to let yourself know
           // you DO want to write
           if (someCondition) { writeToDisk = true; }
       }
       if (writeToDisk)
       {
           var bytes = new byte[outfile.Length];
           outfile.Read(bytes, 0, outfile.Length);
           File.WriteAllBytes(MY_PATH, bytes);
       }
