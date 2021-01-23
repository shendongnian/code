    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    namespace TuermeVonHanoi
    {
    public class TvH
    {
        #region
        IDictionary<string, int> towerMapping = new Dictionary<string, int>()
        {
            {"start", 0}, {"middle", 1}, {"target", 2}
        };
        private string emptyTower = "     |     ";
        private int turns = 0;
        Stack<string>[] towers;
        IList<string> discs = new List<string>()
        {
            {"-----|-----"},
            {" ----|---- "},
            {"  ---|---  "},
            {"   --|--   "},
            {"    -|-    "}
        };
        #endregion
        public TvH(int towerCount)
        {
            towers = new Stack<string>[towerCount];
            initializeTowers();
        }
        private void initializeTowers()
        {
            for (int i = 0; i < towers.Length; i++)
            {
                towers[i] = new Stack<string>();
            }
     
            foreach (var d in discs)
            {
                towers[0].Push(d);
            }
        }
        public void moveAlgorithmic(int n, string a, string b, string c)
        {  
            if (n > 0)
            {
                moveAlgorithmic(n - 1, a, c, b);   
                ++turns;
                Console.Write("\nturn # ");
                if (turns < 10)
                {
                    Console.Write("0");
                }
                Console.WriteLine("{0}      disc # {1}      {2} --> {3}\n", turns, n, a, c);
                moveVisual(a, c);
                moveAlgorithmic(n - 1, b, a, c);                
            }
        }
        private void moveVisual(string start, string target)
        {   
            var element = towers[towerMapping[start]].Pop();
            towers[towerMapping[target]].Push(element);                        
            printContent();
        }
        private void printContent()
        {
            IList<string> t1 = prepareTowerForPrint(towers[0].GetEnumerator());
            IList<string> t2 = prepareTowerForPrint(towers[1].GetEnumerator());
            IList<string> t3 = prepareTowerForPrint(towers[2].GetEnumerator());
            int i = 0;
            while (i < discs.Count)
            {
                object ob1 = t1[i];
                object ob2 = t2[i];
                object ob3 = t3[i];           
                Console.WriteLine("\t{0}\t{1}\t{2}", ob1, ob2, ob3);
                ++i;
            }
        }
        private IList<string> prepareTowerForPrint(Stack<string>.Enumerator enumerator)
        {
            IList<string> towerList = new List<string>();
            int count = 0;
            while (enumerator.MoveNext())
            {
                ++count;
                towerList.Add(enumerator.Current);
            }
         
            int toPush = discs.Count - count;
            for (int i = 0; i < toPush; i++ )
            {
                towerList.Add(emptyTower);
            }
            if (toPush != 0 || toPush != 1)
            {
                towerList = towerList.OrderByDescending(d => d.Count(Char.IsWhiteSpace)).ToList();
            }
            return towerList;
        }
    }
}
