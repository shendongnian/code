    class Program
    {
        static List<string> sentences = new List<string>();
        static List<string> pattern = new List<string>();
        static List<string> results = new List<string>();
        static void Main(string[] args)
        {
            //sentences are in order
            sentences.Add("Bill cat had");
            sentences.Add("Bill had a cat");
            sentences.Add("Cat had Bill");
            sentences.Add("Bill had cats");
            //patters are in order
            pattern.Add("Bill");
            pattern.Add("had");
            pattern.Add("cat");
            // call the searchString method
            results = searchString(sentences, pattern);
            foreach (string res in results)
            {
                Console.WriteLine(res);
            }
            
            Console.Read(); // just keep program running when debugged
        }
        static List<string> searchString(List<string> sentences, List<string> patterns)
        {
            bool result = false;
            List<string> resultLIst = new List<string>();
            foreach (string sen in sentences)
            {
                int j = 0;
                foreach (string pat in pattern)
                {
                    if (sen.Contains(pat))
                    {
                        if (j <= sen.IndexOf(pat))
                        {
                            result = true;
                        }
                        else
                        {
                            result = false;
                            break;
                        }
                        j = sen.IndexOf(pat);
                    }
                    else
                    {
                        result = false;
                        break;
                    }
                }
                if (result)
                    resultLIst.Add(sen); // get the matching sentence
            }
            return resultLIst; // return matchin sentences
        }
    }
