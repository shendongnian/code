        using(srRead = new StreamReader(sOpen))
        using(swWrite = new StreamWriter(sSave))
        {
            try
            {
                while ((slInput = srRead.ReadLine()) != null)
                {
                    double dDoub = double.Parse(slInput);
                    dDoub = dDoub * 2;
                    swWrite.WriteLine(dDoub);
                }
            }
            catch (Exception e)
            {
                 Console.WriteLine("Error! {0}", e.Message);
            }
        }
