     public class MyList<T> : IEnumerable<T>
    {
        private T[] arr;
        public int Count
        {
            get { return arr.Length; }
        }            
    public void Reverse()
        {
            T[] newArr = arr;
            arr = new T[Count];
            int number = Count - 1;
            for (int i = 0; i < Count; i++)
            {
                arr[i] = newArr[number];
                number--;
            }
        }
    }
