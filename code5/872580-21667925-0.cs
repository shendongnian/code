    public class ArrayListDemo
    {
        private ArrayList innerList;
    
        public ArrayListDemo()
        {
            innerList = new ArrayList();
        }
    
        public int Add(string str)
        {
            return innerList.Add(str);
        }
    
        public void Remove(string str)
        {
            innerList.Remove(str);
        }
    
        public string this[int index]
        {
            get
            {
                return innerList[index] as string;
            }
            set
            {
                innerList[index] = value;
            }
        }
    
        public static implicit operator ArrayList(ArrayListDemo stringArrayList)
        {
            return stringArrayList.innerList;
        }
    }
