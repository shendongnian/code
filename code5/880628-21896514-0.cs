    public class MergedData<T,T2>
    {
       public T A;
       public T2 B;
       public MergedData(T A, T2 B)
       {
           this.A = A;
           this.B = B;   
       }
    }
    
    public class A
    {
       public int Id;
       public string Value;
    }
    
    public class B
    {
       public int Id;
       public string Value;
    }
     var listOfMerged = new List<MergedData<A,B>>();
     for (int i=0; i<listOfA.Count; i++)
         listOfMerged.Add(new MergedData<A,B> (listOfA[i],listOfB[i]));
     //  Example of Use
     Console.WriteLine(listOfMerged[0].A.Id);
     Console.WriteLine(listOfMerged[0].B.Value);
