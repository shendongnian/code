    Public class Product{
    
    public List<int> list = new List<int>();
    public int Id;
    Public Product(int id,params int[] list){
       Id = id;
       for (int i = 0; i < list.Length; i++)
            {
                list.Add(list[i]);
            }
    }
    }
