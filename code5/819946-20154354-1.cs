    public class BeforeAndAfterWordFinder
    {
        public string Input { get; private set; }
        private string[] words;
        public BeforeAndAfterWordFinder(string input)
        {
            Input = input;
            words = Input.Split(new string[] { ", ", " " }, StringSplitOptions.None);
        }
        public void Run(int occurance, string word)
        {
            int index = 0;
            OccuranceAfterWord(occurance, word, ref index);
            Print(index);            
        }
        private void OccuranceAfterWord(int occurance, string word, ref int lastIndex, int thisOccurance = 0)
        {
            lastIndex = lastIndex > 0 ? Array.IndexOf(words, word, lastIndex + 1) : Array.IndexOf(words, word);
            
            if (lastIndex != -1)
            {
                thisOccurance++; 
                if (thisOccurance < occurance)
                {
                    OccuranceAfterWord(occurance, word, ref lastIndex, thisOccurance);
                }                
            }            
        }
        private void Print(int index)
        {            
            Console.WriteLine("{0} : {1}", words[index - 1], words[index + 1]);//check for index out of range
        }
    }
