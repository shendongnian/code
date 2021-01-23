    static void Main()
        {
           Console.Write("Write a string: ");
           string line = Console.ReadLine();
           object result;
           if (line != null)
            {
                for(int i=0; i<=line.Length; i++){
                    result = checkChar(line[i]);
                    if(result is bool)
                        break;
                }
                Console.WriteLine(result);
            }
        }    
    
        static object checkChar(char input){
            char[] letters={'f', 'g', 'h'};
            char noResult="#";
            foreach(char letter in letters){
                if(input.Equals(letter))
                    return letter;
                else return false;
            }
        }
