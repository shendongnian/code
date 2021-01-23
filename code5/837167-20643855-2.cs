        public void Pop()
        {
            if (nextFree == -1)
            {
                Console.WriteLine("Stack is empty");
                Console.ReadLine();
            }
            else
            {
                Stack[nextFree] = null;
                nextFree--;
            }
            this.list();
        }
