    public interface IBlock<T> 
        where T : IBlock<T>
    {
    }
    public class Block<T> : Collection<T>, IBlock<Block<T>>
    {        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var list_1=new Block<int[]>();
            list_1.Add(new int[] { 1, 2, 3} );
            list_1.Add(new int[] { 4, 5} );
            var list_2=new Block<int[]>();
            list_2.Add(new int[] { -1, 4} );
            list_2.Add(new int[] { 2, 6, 8} );
            var list_list =new Block<Block<int[]>>();
            list_list.Add(list_1);
            list_list.Add(list_2);
            int x=list_list[1][0][1];
            // x=4
        }
    }
