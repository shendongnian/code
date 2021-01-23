    class stringSections
    {
        private List<string> role = new List<string>();
        private List<string> name = new List<string>();
        public void Input(string input)
        {
            string temp = "";
            for(int i =0;i<input.Length;i++)
            {
                if(input[i]==';')
                {
                    name.Add(temp);
                    temp = "";
                } else if(input[i]==',')
                {
                    role.Add(temp);
                    temp = "";
                } else
                {
                    temp += input[i];
                }
            }
        }
        public List<string> GetAll(string prole)
        {
             List<string> reterners = new List<string>();
             for(int i = 0; i < role.Count;i++)
            {
                if (role[i] == prole)
                {
                    reterners.Add(name[i]);
                }
            }
             return reterners;
        }
    }
