        public string Pop()
        {
            string value = string.Empty;
            
            if (nextFree == -1)
            {
                Console.WriteLine("Stack is empty");
                Console.ReadLine();
            }
            else
            {
                value = Stack[nextFree];
                Stack[nextFree] = null;
                nextFree--;
            }
            this.list();
            return value;
        }
