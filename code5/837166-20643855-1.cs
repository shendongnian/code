        public string Pop()
        {
            if (nextFree == -1)
            {
                Console.WriteLine("Stack is empty");
                Console.ReadLine();
            }
            else
            {
                string value = Stack[nextFree];
                Stack[nextFree] = null;
                nextFree--;
            }
            this.list();
            return value;
        }
