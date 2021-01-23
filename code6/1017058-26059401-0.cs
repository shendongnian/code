    using ILNumerics;
    using System;
    namespace Cell_DBQuery_Example {
        class Program {
            static void Main(string[] args) {
                using (ILScope.Enter()) {
                    ILCell data = Helper.DBQuery(); 
                    // data is: 
                    //Cell [2,2]
                    //[0]: <String>           header 1  <Double> [100,200]           
                    //[1]: <String>           header 2  <Single> [2,3000]  
                    // store into mat file
                    ILMatFile mat = new ILMatFile();
                    var key1 = (string)data.GetArray<string>(0, 0); 
                    mat.AddArray(data.GetArray<double>(0, 1), key1);  // stores rand(100,200) as key: "header1"
                    // proceed with other columns...
                    // write mat file
                    mat.Write("filename"); 
                }
            }
            class Helper : ILMath {
                public static ILRetCell DBQuery() {
                    using (ILScope.Enter()) {
                        // prepare return cell
                        ILCell ret = cell(size(2, 2)); 
                        // todo: fetch data from db and replace below example data
                        ret[0, 0] = "header_1";
                        ret[1, 0] = "header_2";
                        ret[0, 1] = rand(100, 200);
                        ret[1, 1] = ones<float>(2, 3000);
                        return ret; 
                    }
                }
            }
        }
    }
