    public class Word
    {
        private string _inputWord;
        public Word()
        {
            Console.WriteLine("Enter a word");
            _inputWord = Console.ReadLine();
        }
        public void SortAndCount()
        {
            // sort
            char[] array = _inputWord.ToCharArray();
            Array.Sort(array);
            // for all characters
            for(int i = 0; i < array.Length; i++)
            {
                // count
                int count = 0;
                for(int j = 0; j < array.Length; j++)
                    if(array[i] == array[j])
                        count++;
                Console.WriteLine(array[i] + " " + count);
            }
       }
    }
    class Program
    {
        public static void Main()
        {
            Word obj = new Word();
            obj.SortAndCount();
        }
    }
