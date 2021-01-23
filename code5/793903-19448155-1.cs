    public double[] UnSerialize(string Source, char[] separators)
    {
        //splitting Source array by separators   "1|2|3" => Split by '|' => [1],[2],[3]
        string[] tmp = Source.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        double[] result = new double[tmp.Length];
        for(int i=0;i<tmp.Length) {result[i]=Convert.ToDouble(tmp[i]);}
        return result;
    }
