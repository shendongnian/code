       static  void Main()
        {
            string line =  "i [L]ove [B]asketball and [H]ockey";
            int count = 0;
            char temp=' ';
            string str="";
            foreach (char ch in line)
            {
                if (ch == '[')
                {
                    count++;
                }
                else if (count ==1)
                {
                    count++;
                    temp=ch;
                }
                else if(count==2 && ch==']')
                {
                    str+=temp;
                    count=0;
                }              
                else
                {
                    count = 0;
                }
            }
            Console.WriteLine(str);
        }
