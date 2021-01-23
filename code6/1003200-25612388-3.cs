    using ProtoBuf;  
    using system.IO;
    
        [ProtoContract]
        class CudaNetwork {
            [ProtoMember(1)]
            public CudaResult[] results {get;set;}
        }
    
        [ProtoContract]
        class CudaResult {
            [ProtoMember(1)]
            public double[] threshold {get;set;}
            [ProtoMember(2)]
            public double[] weight { get; set; }
    
        }
   
    var myjaggedArr = new double[2][] { new double[3] { 1, 2, 3 }, new double[3] { 6, 7, 8 } };
    var myjaggedArr2 = new double[2][,] { new double[2,3] { {10,10,10}, {20, 30,50} }, new double[2,3] { {60, 70, 80},{40,30,60} } };
     double[] tmp=new double[myjaggedArr2[0].Length];
     Buffer.BlockCopy(myjaggedArr2[0],0,tmp,0,sizeof(double)*tmp.Length);
        
     double[] tmp2=new double[myjaggedArr2[1].Length];
     Buffer.BlockCopy(myjaggedArr2[1],0,tmp2,0,sizeof(double)*tmp2.Length);
    myclass.results[0] = new CudaResult() { threshold = myjaggedArr[0],weight=tmp };
                myclass.results[1] = new CudaResult() { threshold =myjaggedArr[1] ,weight=tmp2 };
    using (var file = File.Create("trainedNetwork.bin")) {
            Serializer.Serialize(file, myclass);
        }
    
    
        CudaNetwork cudaclass;
        using (var file =File.OpenRead("trainedNetwork.bin"))
        {
    
            cudaclass = Serializer.Deserialize<CudaNetwork>(file);
        }
