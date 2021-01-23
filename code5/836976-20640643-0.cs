    private void StoreMetod(string FileName, Type classType)
    {
        using (var fileSt = new System.IO.StreamWriter(FileName))
        {
            foreach (var Method in classType.GetType().GetMethods())
            {
                fileSt.Write(Method.Name);
                fileSt.Write("\t");
                fileSt.Write(Method.ReturnType == null ? "" : Method.ReturnType.FullName );
                fileSt.Write("\t");
                foreach (var prm in Method.GetParameters())
                {
                    //ect...
                }
            }
        }
    }
    private void LoadMethod(string FileName, Object  instant)
    {
        using (var fileSt = new System.IO.StreamReader (FileName))
        {
            while (!fileSt.EndOfStream)
            {
                var lineMethodArg = fileSt.ReadLine().Split('\t');
                var methodName = lineMethodArg[0];
                var typeReturnName = lineMethodArg[1];
                //set parameters, Return type Ect...
                instant.GetType().GetMethod("FileOpen").Invoke(instant, {prms} );
            }
        }
    }
