    public class Vokabel
    {
        string DV;
        string eV;
        public string _DV
        {
            get { return DV; }
            set { DV = value; }
        }
        public string EV
        {
            get { return eV; }
            set { eV = value; }
        }
        public Vokabel(string dv, string ev)
        {
            this._DV = dv;
            this.EV = ev;
        }
        public static implicit operator Vokabel(string vals)
        {
            var valsArray = vals.Split(':');
            return new Vokabel(valsArray[0], valsArray[1]);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Vokabel> Vokabel1 = new List<Vokabel>();
            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Enter a Vokabel[" + i + "]:");
                string Userchoice = Console.ReadLine();
                if (string.IsNullOrEmpty(Userchoice))
                {
                    break;
                }
                Vokabel1.Add(Userchoice);
            }
        }
    }
