    public int FilterArray(List<double> Values, double Offset, out double[] Results)
    {
   		foreach(double value in new List<double>(Values))
   		{
   			// some logic
   			Values.Remove(value);
   		}
        return 0; //??
    }
