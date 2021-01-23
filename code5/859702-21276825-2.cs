    public static void insert(String[] name ,String[] info)
    {
		String Names = "";
		String Cols = "";
		
		for(int i=0;i < name.Length;i++)
		{
  			Names += (Names == "" ? "" :  ", ") + name[i];
  			Cols += (Cols == "" ? "" : ", ") + "'" + info[i] + "'"; 
		}
		String Query = "insert into Account (" + Names + ") Values (" + Cols + ")";
		Console.WriteLine(Query);
    }
