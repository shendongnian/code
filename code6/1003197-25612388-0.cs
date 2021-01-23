     using system.IO;
        using System.Runtime.Serialization.Formatters.Binary;
    
    
        [System.Serializable]
        class CudaNetwork {
            public CudaResult[] results {get;set;}
        }
        [System.Serializable]
        class CudaResult {
            public double[] threshold {get;set;}
            public double[,] weight { get; set; }
        
        }
        var myjaggedArr = new double[2][] { new double[3] { 1, 2, 3 }, new double[3] { 6, 7, 8 } };
        var myjaggedArr2 = new double[2][,] { new double[2,3] { {10,10,10}, {20, 30,50} }, new double[2,3] { {60, 70, 80},{40,30,60} } };
    
    
        var myclass = new CudaNetwork
                    {
                results = new CudaResult[2] 
               };
        
                    myclass.results[0] = new CudaResult() { threshold = myjaggedArr[0],weight=myjaggedArr2[0] };
                    myclass.results[1] = new CudaResult() { threshold = myjaggedArr[1],weight=myjaggedArr2[1] };
    
    var formatter = new BinaryFormatter();
    
    using (
    var file = File.Create("mydata.bin"))
    {
    
        formatter.Serialize(file, myclass);
    }
    using (
    var file = File.OpenRead("mydata.bin"))
    {
        var obj = formatter.Deserialize(file);
    }
