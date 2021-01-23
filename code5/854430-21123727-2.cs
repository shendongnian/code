    using System;
    
    namespace CSharp_matlab_com
    {
    class Program
    {
        static void Main(string[] args)
        {
            MLApp.MLAppClass matlab = new MLApp.MLAppClass();
    
            // create variables: a_0, a_1, ..., a_4
            for (int k = 0; k < 5; k++) {
                matlab.Execute(string.Format("a_{0} = rand(2);", k));
            }
    
            // retrieve variables from MATLAB and print their contents
            object a;
            for (int k = 0; k < 5; k++) {
                // current variable name
                string varname = string.Format("a_{0}", k);
    
                // get data array
                a = null;    // without this line, an exception is thrown!
                matlab.GetWorkspaceData(varname, "base", out a);
    
                // print contents
                var arr = (double[,]) a;
                Console.WriteLine("\nndims(a) = {0}, numel(a) = {1}", arr.Rank, arr.Length);
                for (int i = 0; i < arr.GetLength(0); i++) {
                    for (int j = 0; j < arr.GetLength(1); j++) {
                        Console.WriteLine("{0}[{1},{2}] = {3}", varname, i, j, arr[i,j]);
                    }
                }
            }
        }
    }
    }
