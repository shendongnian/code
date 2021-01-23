    <Query Kind="Program">
      <Reference>&lt;RuntimeDirectory&gt;\System.Windows.Forms.dll</Reference>
      <NuGetReference>Accord.Controls</NuGetReference>
      <NuGetReference>Accord.Math</NuGetReference>
      <Namespace>Accord.Controls</Namespace>
      <Namespace>Accord.Math</Namespace>
    </Query>
    
    void Main()
    {
    	double[] x = { 1, 2, 3 };
    	double[] y = { 4, 5, 6 };
    	
    	var M = Matrix.MeshGrid(x, y);
    	
    	double[,] X = M.Item1;
    	double[,] Y = M.Item2;
    
    	DataGridBox.Show(X, "X");
    	DataGridBox.Show(Y, "Y");
    }
